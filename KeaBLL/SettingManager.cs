using System;
using System.Collections.Generic;
using System.Linq;
using KeaDAL;
using ServiceLib;

namespace KeaBLL
{
    public static class SettingManager
    {
        public static T ReadSetting<T> (string setting)
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

        public static void WriteSetting(string setting, string value)
        {
            Setting innerSetting = null;
            try
            {
                using (KeaContext context = new KeaContext())
                {
                    innerSetting = context.Settings.Find(setting);
                    if (innerSetting != null)
                    {    
                        innerSetting.Value = value;
                        CacheManager.SetValue(setting, value);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Do not find setting: " + setting);
                    }
                }
            }
            catch (Exception) { }
        }

        public static List<Setting> GetSettingList()
        {
            List<Setting> result = null;
            using (KeaContext context = new KeaContext())
            {
                result = context.Settings.ToList();
            }
            return result;
        }
    }
}