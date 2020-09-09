using System;

namespace GW.AspNetTraining.TrainingsWebApp.Business
{
    public class OrderEntity
    {
        public Guid Id { get; set; }

        public AttendeeEntity[] Attendees { get; set; }

        public decimal Price { get; set; }

        public TrainingEntity Training { get; set; }
    }
}