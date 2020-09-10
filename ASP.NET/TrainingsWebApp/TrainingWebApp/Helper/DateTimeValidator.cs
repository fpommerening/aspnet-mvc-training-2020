using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GW.AspNetTraining.TrainingsWebApp.Helper
{
    public class DateTimeValidator : ValidationAttribute
    {
        public DateTimeValidator(DateTime maxLimit)
        {
            MaxLimit = maxLimit;
        }

        public DateTime MaxLimit { get; set; } = DateTime.MaxValue;

        public override bool IsValid(object value)
        {
            if (value is DateTime dt)
            {
                return dt < MaxLimit;
            }
            return base.IsValid(value);
        }
    }
}