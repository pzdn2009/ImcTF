using ImcFramework.Ioc;
using ImcFramework.LogPool;
using System.Collections.Generic;

namespace ImcFramework
{
    public interface IServiceModule
    {
        string Name { get; }

        bool Enable { get; set; }

        void Initialize();

        void Start();

        void Stop();

        ILoggerPool LoggerPool { get; set; }

        IIocManager IocManager { get; set; }

        IEnumerable<IServiceModule> DependencyModules { get; set; }
    }
}
