using GW.AspNetTraining.TrainingsWebApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GW.AspNetTraining.TrainingsWebApp.Models
{
    public class Training
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Titel")]
        public string Title { get; set; }

        [DisplayName("Bescheibung")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Dauer")]
        [Range(1, 10)]
        public int Duration { get; set; }

        [Required]
        [DisplayName("Niveau")]
        public int Level { get; set; }

        // HH
        // HL
        // ECK
        // MD
        // HB
        [Required]
        [DisplayName("Standort")]
        public string Location { get; set; }

        [DisplayName("Freigabe")]
        public bool Approval { get; set; }

        
        public decimal Price { get; set; }

        [DisplayName("Verfügbar ab")]
       // [DateTimeInPastValidator(ErrorMessage ="Bitte nur in der Vergangenheit")]
        [DateTimeInPastValidator()]
        //[DateTimeValidator(new Date)]

        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }
    }
}