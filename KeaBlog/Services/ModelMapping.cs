using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmitMapper;
using KeaBlog.Areas.Admin.Models;
using KeaDAL;

namespace KeaBlog.Services
{
    public static class ModelMapping
    {
        public static void PostAuthorToViewModel (PostAuthor model, PostAuthorViewModel viewModel)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<PostAuthor, PostAuthorViewModel>();
            viewModel = mapper.Map(model, viewModel);
        }
    }
}