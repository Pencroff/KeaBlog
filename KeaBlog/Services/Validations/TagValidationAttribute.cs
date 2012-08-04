using System;
using System.ComponentModel.DataAnnotations;
using KeaBLL;

namespace KeaBlog.Services.Validations
{
    public class TagValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string tag = value != null ? value.ToString() : String.Empty;
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                // ToDo Resource
                ErrorMessage = "Wrong tag name. It is not unique.";
            }
            if (TagManager.GetTagByName(tag) != null)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}