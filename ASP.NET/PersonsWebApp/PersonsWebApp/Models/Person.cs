using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FP.AspNetTraining.PersonsWebApp.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [DisplayName("Geburtstag")]
        public DateTime Birthday { get; set; }

        [DisplayName("Bundesland")]
        public string Location { get; set; }

        public bool IsNew { get; set; }
    }
}