using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Gombka.pl.Models;

namespace Gombka.pl.Attributes
{
    public class AlphanumAttribute : ValidationAttribute
    { 
        public string GetErrorMessage() => "Pole musi zawierać tylko znaki alfanumeryczne.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!value.ToString().All(char.IsLetterOrDigit))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
