using ImcFramework.Ioc;

namespace ImcFramework.Configuration
{
    public interface IImcStartupConfiguration
    {
        IIocManager IocManager { get; }

        IModuleConfigurations Modules { get; }
    }
}
