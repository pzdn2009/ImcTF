namespace ImcFramework.Configuration
{
    public class ModuleConfigurations : IModuleConfigurations
    {
        public IImcStartupConfiguration Configuration
        {
            get;
        }

        public ModuleConfigurations(IImcStartupConfiguration imcStartupConfiguration)
        {
            Configuration = imcStartupConfiguration;
        }
    }
}
