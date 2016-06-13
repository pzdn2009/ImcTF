using ImcFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public abstract class ModuleExtensionBase : IModuleExtension
    {
        public ModuleExtensionBase()
        {
            //创建
        }

        public ServiceContext ServiceContext { get; set; }


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
    }
}
