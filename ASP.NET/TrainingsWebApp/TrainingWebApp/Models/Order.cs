using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GW.AspNetTraining.TrainingsWebApp.Models
{
    public class Order
    {
        public Attendee[] Attendees { get; set; }

        public decimal Price { get; set; }

        public Guid TrainingId { get; set; }
    }
}