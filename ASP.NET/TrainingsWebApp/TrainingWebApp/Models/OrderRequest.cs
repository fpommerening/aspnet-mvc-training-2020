using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GW.AspNetTraining.TrainingsWebApp.Models
{
    public class OrderRequest
    {
        public Attendee[] Attendees { get; set; }

        public Guid TrainingId { get; set; }
    }
}