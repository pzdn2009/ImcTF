using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {
        }

        public virtual bool Enable { get; set; }
    }
}
