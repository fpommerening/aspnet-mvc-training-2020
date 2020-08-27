using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FP.AspNetTraining.PersonsWebApp.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [DisplayName("Name")]
        [Required()]
        public string Name { get; set; }

        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [DisplayName("Geburtstag")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthdayEdit
        {
            get
            {
                return Birthday;
            }
            set
            {
                Birthday = value;
            }

        }

        [DisplayName("Geburtstag")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false,
           DataFormatString = "{0:d}")]
        public DateTime Birthday
        {
            get; set;
        }

        [DisplayName("Bundesland")]
        public string Location { get; set; }

        public bool IsNew { get; set; }
    }
}