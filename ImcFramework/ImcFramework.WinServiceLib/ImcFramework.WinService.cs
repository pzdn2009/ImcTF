using ImcFramework.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.WinService
{
    public partial class ImcFrameworkWinService : ServiceBase
    {
        public ImcFrameworkWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceManager.StartAll();
        }

        protected override void OnStop()
        {
            ServiceManager.StopAll();
        }
    }
}
