using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Gombka.pl.Models;

namespace Gombka.pl.Attributes
{
    public class NoSpaceAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => "Pole nie może zawierać spacji.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Any(char.IsWhiteSpace))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
