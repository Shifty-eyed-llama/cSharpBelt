using System;
using System.ComponentModel.DataAnnotations;

namespace cSharpBelt.Extensions
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(DateTime.Now > Convert.ToDateTime(value))
            {
                return new ValidationResult("How are people supposed to attend in the past?");
            }
            return ValidationResult.Success;
        }
    }
}