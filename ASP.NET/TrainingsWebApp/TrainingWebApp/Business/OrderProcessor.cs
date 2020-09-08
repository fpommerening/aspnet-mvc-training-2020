using System;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public class OrderProcessor
    {
        private readonly TrainingRepository _trainingRepository;

        public OrderProcessor(TrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public OrderEntity OrderTraining(Guid trainingId, AttendeeEntity[] attendees)
        {
            if (attendees == null)
            {
                throw new ArgumentNullException(nameof(attendees));
            }

            if (attendees.Length == 0)
            {
                throw new InvalidOperationException("The order needs at least one attendees");
            }

            var training = _trainingRepository.GetTrainingById(trainingId);

            var order = new OrderEntity
            {
                Attendees = attendees,
                Training = training
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