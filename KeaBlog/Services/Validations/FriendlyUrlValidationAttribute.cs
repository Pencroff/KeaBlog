using System;
using System.ComponentModel.DataAnnotations;

namespace KeaBlog.Services.Validations
{
    public class FriendlyUrlValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                // ToDo Rosource
                ErrorMessage = "Wrong friendly url. It is not unique.";
            }
            return ValidationResult.Success;
        }
    }
}