using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Cache
{
    public interface ICache : IDisposable
    {
        string Name { get; }

        object Get(string key);

        void Set(string key, object value, TimeSpan? timeout);

        void Remove(string key);

        void Clear();
    }
}
