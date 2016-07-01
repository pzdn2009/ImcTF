using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.SignalRExt
{
    public class SignalRClientModule : ServiceModuleBase, IModuleExtension
    {
        private const string NAME = "SIGNALR_MODULE_EXTENSION";

        public SignalRClientModule()
        {

        }

        public override string Name
        {
            get { return NAME; }
        }

        public ServiceContext ServiceContext
        {
            get; set;
        }

        public override void Start()
        {
            if (!string.IsNullOrEmpty(Define.SignalRUrl))
            {
                SignalRClientManager.RegisterAll();
            }
        }

        public override void Stop()
        {
            if (!string.IsNullOrEmpty(Define.SignalRUrl))
            {
                SignalRClientManager.UnRegisterAll();
            }
        }
    }
}
