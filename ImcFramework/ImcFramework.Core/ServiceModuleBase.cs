using System.Collections.Generic;
using Common.Logging;
using ImcFramework.Ioc;

namespace ImcFramework.Core
{
    public abstract class ServiceModuleBase : IServiceModule
    {
        public virtual IEnumerable<IServiceModule> DependencyModules
        {
            get; set;
        }

        public abstract string Name
        {
            get;
        }

        public IIocManager IocManager { get; set; }

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {
        }

        public virtual bool Enable { get; set; }

        public ILog Logger { get; set; }
    }
}
