using System;
using System.Threading.Tasks;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public class OrderProcessor
    {
        private readonly ITrainingRepository _trainingRepository;

        public OrderProcessor(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<OrderEntity> OrderTraining(Guid trainingId, AttendeeEntity[] attendees)
        {
            if (attendees == null)
            {
                throw new ArgumentNullException(nameof(attendees));
            }

            if (attendees.Length == 0)
            {
                throw new InvalidOperationException("The order needs at least one attendees");
            }

            var training = await _trainingRepository.GetTrainingById(trainingId).ConfigureAwait(false);

            var order = new OrderEntity
            {
                Attendees = attendees,
                Training = training,
                Id = Guid.NewGuid()
            };

            if (attendees.Length == 1)
            {
                order.Price = training.Price;
            }
            else if (attendees.Length == 2)
            {
                order.Price = training.Price * 1.8m; 
            }
            else
            {
                order.Price = training.Price * attendees.Length * 0.8m;
            }

            return order;
        }
    }
}