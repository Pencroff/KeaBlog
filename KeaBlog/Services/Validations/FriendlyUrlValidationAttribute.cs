using System;
using System.ComponentModel.DataAnnotations;
using KeaBLL;
using ServiceLib;

namespace KeaBlog.Services.Validations
{
    public class FriendlyUrlValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string url = value.ToString();
            url = url.ToTranslit().Slugify(256);
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                // ToDo Resource
                ErrorMessage = "Wrong friendly url. It is not unique.";
            }
            if (PostManager.GetPostByUrl(url) != null)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}