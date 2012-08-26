using System;
using System.ComponentModel.DataAnnotations;
using KeaBLL;

namespace KeaBlog.Services.Validations
{
    public class CategoryValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string category = value != null ? value.ToString() : String.Empty;
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                // ToDo Resource
                ErrorMessage = "Wrong category name. It is not unique.";
            }
            if (CategoryManager.GetCategoryByName(category) != null)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}