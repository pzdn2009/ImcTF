using ImcFramework.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Cache.Memory
{
    public class MemoryCacheManager : ICacheManager
    {
        protected IIocManager IocManager { get; private set; }
        private static Dictionary<string, ICache> dict = new Dictionary<string, ICache>();
        private object lockObject = new object();

        public MemoryCacheManager(IIocManager iocManager)
        {
            IocManager = iocManager;
        }

        public ICache GetCache(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICache> GetCaches()
        {
            throw new NotImplementedException();
        }
    }
}
