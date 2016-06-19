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
        public ModuleExtensionBase(ServiceContext serviceContext)
        {
            this.ServiceContext = serviceContext;
        }

        public ServiceContext ServiceContext { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
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
