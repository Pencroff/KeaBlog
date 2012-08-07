using System;
using System.ComponentModel.DataAnnotations;
using KeaBLL;
using KeaBlog.Areas.Admin.Models;
using KeaDAL;
using ServiceLib;

namespace KeaBlog.Services.Validations
{
    public class FriendlyUrlValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string url = value!=null?value.ToString():String.Empty;
            PostFull post = null;
            PostViewModel viewModel = (PostViewModel) validationContext.ObjectInstance;
            url = url.ToTranslit().Slugify(256);
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                // ToDo Resource
                ErrorMessage = "Wrong friendly url. It is not unique.";
            }
            post = PostManager.GetPostByUrl(url);
            if (post != null && viewModel.Id != post.Id)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}