using GW.AspNetTraining.TrainingsWebApp.Business;
using GW.AspNetTraining.TrainingsWebApp.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

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

        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Order))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var entities = await _trainingRepository.GetOrders();
            var entity = entities.SingleOrDefault(x => x.Id == id);
            if(entity == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            var model = new Order
            {
                Attendees = entity.Attendees.Select(a => new Attendee
                {
                    FirstName = a.FirstName,
                    Name = a.Name
                }).ToArray(),
                Price = entity.Price,
                TrainingId = entity.Training.Id,
                Id = entity.Id
            };

            return Ok(model);
        }
    }
}
