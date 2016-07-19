using ImcFramework.Ioc;

namespace ImcFramework.Configuration
{
    public class ImcStartupConfiguration : IImcStartupConfiguration
    {
        public IIocManager IocManager
        {
            get; private set;
        }

        public IModuleConfigurations Modules
        {
            get; private set;
        }

        public ImcStartupConfiguration(IIocManager iocManager)
        {
            IocManager = iocManager;
        }

        public void Initialize()
        {
            Modules = IocManager.Resolve<IModuleConfigurations>();
        }
    }
}
