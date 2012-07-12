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
        public static void PostFullToViewModel (PostFull model, PostViewModel viewModel)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<PostFull, PostViewModel>();
            viewModel = mapper.Map(model, viewModel);
        }

        public static void PostShortToViewModel(PostShort model, PostViewModel viewModel)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<PostShort, PostViewModel>();
            viewModel = mapper.Map(model, viewModel);
        }

        public static void PostViewModelToModel(PostViewModel viewModel, Post model)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<PostViewModel, Post>();
            model = mapper.Map(viewModel, model);
        }
    }
}