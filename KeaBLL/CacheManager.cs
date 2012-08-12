using System;
using System.Runtime.Caching;

namespace KeaBLL
{
    public static class CacheManager
    {
        public static object GetValue(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache[key] != null)
                return cache[key];
            else
                return null;
        }

        public static void SetValue(string key, object value, double duration = 15/*minute*/)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.UtcNow.AddMinutes(duration);
            cache.Remove(key);
            cache.Add(key, value, policy);
        }
    }
}