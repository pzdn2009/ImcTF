using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Cache.Memory
{
    public class DefaultMemoryCache : ICache
    {
        private TimeSpan DefaultSlidingExpireTime = TimeSpan.FromDays(1);
        private MemoryCache memoryCache;

        public DefaultMemoryCache(string name)
        {
            this.Name = name;
            memoryCache = new MemoryCache(Name);
        }

        public string Name
        {
            get; private set;
        }

        public void Clear()
        {
            memoryCache.Dispose();
            memoryCache = new MemoryCache(Name);
        }

        public void Dispose()
        {
            memoryCache.Dispose();
        }

        public object Get(string key)
        {
            return memoryCache.Get(key);
        }

        public void Remove(string key)
        {
            memoryCache.Remove(key);
        }

        public void Set(string key, object value, TimeSpan? timeout)
        {
            memoryCache.Set(
                key,
                value,
                new CacheItemPolicy
                {
                    SlidingExpiration = timeout ?? DefaultSlidingExpireTime
                });
        }
    }
}
