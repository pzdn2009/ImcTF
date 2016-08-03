using Common.Logging;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using System.Collections.Generic;

namespace ImcFramework.Core
{
    /// <summary>
    /// Service module base,<seealso cref="IServiceModule"/> .
    /// </summary>
    public abstract class ServiceModuleBase : IServiceModule
    {
        public ServiceModuleBase()
        {
            Enable = true;
        }

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
            LoggerPool?.GetLogger("").Info(Name + " Start...");
        }

        public virtual void Stop()
        {
            LoggerPool?.GetLogger("").Info(Name + " Stop...");
        }

        public virtual void Initialize()
        {
            LoggerPool?.GetLogger("").Info(Name + " Initialize...");
        }

        public virtual bool Enable { get; set; }

        public ILoggerPool LoggerPool { get; set; }
    }
}
