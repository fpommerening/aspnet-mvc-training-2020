using FluentAssertions;
using FluentAssertions.Common;
using GW.AspNetTraining.TrainingsWebApp.Business;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingsTest
{
    [TestFixture]
    public class OrderprocessorTest
    {
        [Test]
        public void AttendeesNullShouldThrowArgumentNullExcpetion()
        {
            var trainingId = Guid.Empty;
            AttendeeEntity[] attendees = null;
            var repo = NSubstitute.Substitute.For<ITrainingRepository>();
            var sut = new OrderProcessor(repo);

            async Task result() => await sut.OrderTraining(trainingId, attendees);

            //NUnit
            Assert.That(result, Throws.ArgumentNullException);
        }

        [Test]
        public void AttendeesEmptyShouldThrowInvalidOperationExcpetion()
        {
            var trainingId = Guid.Empty;
            var attendees = new AttendeeEntity[]{ };
            var repo = NSubstitute.Substitute.For<ITrainingRepository>();
            var sut = new OrderProcessor(repo);

            async Task result() => await sut.OrderTraining(trainingId, attendees);

            //NUnit
            Assert.That(result, Throws.InvalidOperationException);
        }
        [Test]
        public async Task OneAttendeeShouldPayFullPrice()
        {
            var trainingId = Guid.Empty;
            var price = 345m;
            var attendees = new AttendeeEntity[]
            {
                new AttendeeEntity{FirstName ="Max", Name = "Mustermann"}
            };
            var repo = Substitute.For<ITrainingRepository>();
            repo.GetTrainingById(trainingId).Returns(new TrainingEntity
            {
                Price = price
            });
            
            var sut = new OrderProcessor(repo);
            // ACT
            var result = await sut.OrderTraining(trainingId, attendees);
            // ASSERT
            // NUnit
            //Assert.That(result.Price, Is.EqualTo(price));
            Assert.AreEqual(result.Price, price);
        }

        [Test]
        public async Task TwoAttendeesShouldPay90Percent()
        {
            var trainingId = Guid.Empty;
            var trainingPrice = 100m;
            var orderPrice = 180m;
            var attendees = new AttendeeEntity[]
            {
                new AttendeeEntity{FirstName ="Max", Name = "Mustermann"},
                new AttendeeEntity{FirstName ="Max", Name = "Mustermann"}
            };
            var repo = Substitute.For<ITrainingRepository>();
            repo.GetTrainingById(trainingId).Returns(new TrainingEntity
            {
                Price = trainingPrice
            });

            var sut = new OrderProcessor(repo);
            // ACT
            var result = await sut.OrderTraining(trainingId, attendees);
            // ASSERT
            // NUnit
            //Assert.That(result.Price, Is.EqualTo(price));
            Assert.AreEqual(result.Price, orderPrice);
        }

        [Test]
        [TestCaseSource(typeof(OrderProcessorTestData), nameof(OrderProcessorTestData.TestCases))]
        public async Task ThreeAndMoreAttendeesShouldPay80Percent(List<AttendeeEntity> attendees, decimal trainingPrice, decimal orderprice)
        {
            var trainingId = Guid.Empty;
            var repo = Substitute.For<ITrainingRepository>();
            repo.GetTrainingById(trainingId).Returns(new TrainingEntity
            {
                Price = trainingPrice
            });
            var sut = new OrderProcessor(repo);

            var result = await sut.OrderTraining(trainingId, attendees.ToArray());

            Assert.That(result.Price, Is.EqualTo(orderprice));
        }

        [Test]
        [TestCaseSource(typeof(OrderProcessorTestData), nameof(OrderProcessorTestData.TestCasesWithResult))]
        public async Task<decimal> ThreeAndMoreAttendeesShouldPay80PercentWithResult(List<AttendeeEntity> attendees, decimal trainingPrice)
        {
            var trainingId = Guid.Empty;
            var repo = Substitute.For<ITrainingRepository>();
            repo.GetTrainingById(trainingId).Returns(new TrainingEntity
            {
                Price = trainingPrice
            });
            var sut = new OrderProcessor(repo);

            var result = await sut.OrderTraining(trainingId, attendees.ToArray());

            return result.Price;
        }

        [Test]
        public void InvalidTrainingIdShouldThrowExceptionFromRepo()
        {
            var trainingId = Guid.Empty;
            var attendees = new AttendeeEntity[]
            {
                new AttendeeEntity{FirstName ="Max", Name = "Mustermann"}
            };
            var repo = Substitute.For<ITrainingRepository>();
            //repo.When(x => x.GetTrainingById(trainingId)).Do(x => { async  throw new ArgumentOutOfRangeException(); });
            repo.GetTrainingById(trainingId).Throws<ArgumentOutOfRangeException>();
            //repo.GetTrainingById(trainingId).Returns(x =>Task.Run(()=> throw new ArgumentOutOfRangeException()));

            var sut = new OrderProcessor(repo);

            async Task result() => await sut.OrderTraining(trainingId, attendees);

            //NUnit
            //result.Should().Throws<ArgumentOutOfRangeException>();
            Assert.That(result, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
