using ImcFramework.WinService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.WinServiceLib
{
    public class WinServiceRunHelper
    {
        public static void RunImcFrameworkWinService()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new ImcFrameworkWinService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
