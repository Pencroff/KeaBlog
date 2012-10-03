using System;
using System.ComponentModel.DataAnnotations;
using KeaBLL;
using KeaBlog.Areas.KeaAdmin.Models;
using KeaDAL;

namespace KeaBlog.Services.Validations
{
    public class CategoryValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string categoryName = value != null ? value.ToString() : String.Empty;
            CategoryViewModel viewModel = (CategoryViewModel)validationContext.ObjectInstance;
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                // ToDo Resource
                ErrorMessage = "Wrong category name. It is not unique.";
            }
            Category category = CategoryManager.GetCategoryByName(categoryName);
            if (category != null && viewModel.Id != category.Id)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}