using System.ComponentModel;
using System.ServiceProcess;

namespace MyService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : ImcFramework.WinServiceLib.ImcSvcInstallerBase
    {
        protected override string GetDescription()
        {
            return "My Sample Service";
        }

        protected override string GetSerivceName()
        {
            return "MyService";
        }

        protected override ServiceStartMode GetServiceStartMode()
        {
            return ServiceStartMode.Automatic;
        }
    }
}
