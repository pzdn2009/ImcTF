using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Cache
{
    public interface ICacheManager
    {
        IEnumerable<ICache> GetCaches();

        ICache GetCache(string name);
    }
}
