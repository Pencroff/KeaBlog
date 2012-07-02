using EmitMapper;

namespace ServiceLib.Interfaces
{
    public static class MappingOperations
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
}