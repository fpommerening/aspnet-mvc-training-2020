using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP.AspNetTraining.PersonsWebApp.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public DateTime Birthday { get; set; }

        public string Location { get; set; }

        public bool IsNew { get; set; }
    }
}