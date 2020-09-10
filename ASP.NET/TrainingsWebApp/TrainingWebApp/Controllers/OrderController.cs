using GW.AspNetTraining.TrainingsWebApp.Business;
using GW.AspNetTraining.TrainingsWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GW.AspNetTraining.TrainingsWebApp.Controllers
{
    public class OrderController : ApiController
    {
        private OrderProcessor _orderProcessor;
        private ITrainingRepository _trainingRepository;

        public OrderController(OrderProcessor orderProcessor, ITrainingRepository trainingRepository)
        {
            _orderProcessor = orderProcessor;
            _trainingRepository = trainingRepository;
        }

        public async Task Post([FromBody] OrderRequest orderRequest)
        {
            var trainingId = orderRequest.TrainingId;
            var attendees = orderRequest.Attendees.Select(x => new AttendeeEntity
            {
                FirstName = x.FirstName,
                Name = x.Name
            }).ToArray();

            var order = await _orderProcessor.OrderTraining(trainingId, attendees);
            await _trainingRepository.SaveOrder(order);
        }

        //public async Task Put(Guid orderId, [FromBody] OrderRequest orderRequest)
        //{
        //    var trainingId = orderRequest.TrainingId;
        //    var attendees = orderRequest.Attendees.Select(x => new AttendeeEntity
        //    {
        //        FirstName = x.FirstName,
        //        Name = x.Name
        //    }).ToArray();

        //    var order = await _orderProcessor.OrderTraining(trainingId, attendees);
        //    await _trainingRepository.SaveOrder(order);
        //}

        public async Task<Order[]> Get()
        {
            var entities = await _trainingRepository.GetOrders();
            var models = entities.Select(x => new Order
            {
                Attendees = x.Attendees.Select(a => new Attendee
                {
                    FirstName = a.FirstName,
                    Name = a.Name
                }).ToArray(),
                Price = x.Price,
                TrainingId = x.Training.Id,
                Id = x.Id
            });
            return models.ToArray();
        }
    }
}
