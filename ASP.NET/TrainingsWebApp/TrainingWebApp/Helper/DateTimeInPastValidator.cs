using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GW.AspNetTraining.TrainingsWebApp.Helper
{
    public class DateTimeInPastValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;
            if (value is DateTime dt)
            {
                if(dt > DateTime.Now)
                {
                    if(string.IsNullOrEmpty(ErrorMessage))
                    {
                        return new ValidationResult("Only in Past");
                    }
                    else
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                    
                }
            }
            return ValidationResult.Success; ;
        }
    }
}