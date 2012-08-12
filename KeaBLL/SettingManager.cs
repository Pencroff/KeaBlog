using System;
using KeaDAL;
using ServiceLib;

namespace KeaBLL
{
    public static class SettingManager
    {
        public static T ReadSetting<T> (string setting) where T:struct 
        {
            Setting innerSetting = null;
            string innerResult = null;
            T result = default (T);
            try
            {
                innerResult = CacheManager.GetValue(setting) as string;
                if (String.IsNullOrEmpty(innerResult))
                {
                    using (KeaContext context = new KeaContext())
                    {
                        innerSetting = context.Settings.Find(setting);
                        if (innerSetting != null)
                        {
                            CacheManager.SetValue(innerSetting.Name, innerSetting.Value);
                            innerResult = innerSetting.Value;
                        }
                    }   
                }
                result = Service.Convert<T>(innerResult);
            }
            catch (Exception) { }
            return result;
        }

        public static void WriteSetting<T>(string setting, T value) where T : struct
        {
            Setting innerSetting = null;
            string innerValue = value.ToString();
            try
            {
                using (KeaContext context = new KeaContext())
                {
                    innerSetting = context.Settings.Find(setting);
                    if (innerSetting != null)
                    {    
                        innerSetting.Value = innerValue;
                        CacheManager.SetValue(setting, innerValue);
                    }
                    else
                    {
                        throw new Exception("Do not find setting: " + setting);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}