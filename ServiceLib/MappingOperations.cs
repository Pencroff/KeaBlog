using EmitMapper;
using EmitMapper.MappingConfiguration;

namespace ServiceLib
{
    public static class MappingOperation
    {
        public static U ModelToView<T, U>(T param)
            where T : class
            where U : class
        {
            U result;
            result = ObjectMapperManager.DefaultInstance.GetMapper<T, U>().Map(param);
            return result;
        }
         
    }

    public static class ModelMapping
    {
        public static void ModelToViewModel<TF, TT>(TF model, TT viewModel)
                                    where TF : class
                                    where TT : class
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TF, TT>();
            viewModel = mapper.Map(model, viewModel);
        }

        public static void ViewModelToModel<TF, TT>(TF viewModel, TT model)
                                    where TF : class
                                    where TT : class
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TF, TT>();
            model = mapper.Map(viewModel, model);
        }

        public static void OneToOne<TF, TT>(TF modelFrom, TT modelTo, string[] ignoreMembers = null)
                                where TF : class
                                where TT : class
        {
            ObjectsMapper<TF, TT> mapper = null;
            if (ignoreMembers == null)
            {
                mapper = ObjectMapperManager.DefaultInstance.GetMapper<TF, TT>();
            }
            else
            {
                mapper = ObjectMapperManager.DefaultInstance.GetMapper<TF, TT>(new DefaultMapConfig().IgnoreMembers<TF, TT>(ignoreMembers));
            }
            modelTo = mapper.Map(modelFrom, modelTo);
        }
    }
}