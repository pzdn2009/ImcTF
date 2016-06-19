using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

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
