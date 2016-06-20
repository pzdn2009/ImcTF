using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.SignalRExt
{
    public class SignalRClientModule : ModuleExtensionBase
    {
        private const string NAME = "SIGNALR_MODULE_EXTENSION";

        public SignalRClientModule(ServiceContext serviceContext)
            : base(serviceContext)
        {

        }

        public override string Name
        {
            get { return NAME; }
        }

        public override void Start()
        {
            SignalRClientManager.RegisterAll();
        }

        public override void Stop()
        {
            SignalRClientManager.UnRegisterAll();
        }
    }
}
