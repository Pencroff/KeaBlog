using System.ComponentModel;

namespace ServiceLib
{
    public static class Service
    {
        public static T Convert<T>(this string input)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                return (T) converter.ConvertFromString(input);
            }
            return default(T);
        }    
    }
}