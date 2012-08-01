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
        public static void ModelToViewModel<TF, TT>(TF model, TT viewModel)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TF, TT>();
            viewModel = mapper.Map(model, viewModel);
        }

        public static void ViewModelToModel<TF, TT>(TF viewModel, TT model)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TF, TT>();
            model = mapper.Map(viewModel, model);
        }
    }
}