using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Cache
{
    public interface ICache
    {
        string Name { get; }

        object Get(ICacheKey key);

        object Get(string key);

        void Set(ICacheKey key, object data, int timeout);

        void Set(string key, object data, int timeout);

        void Remove(ICacheKey key);
    }
}
