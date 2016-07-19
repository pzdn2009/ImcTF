using System.Collections.Generic;

namespace ImcFramework.Core.SignalRExt
{
    public class SignalRClientModule : ServiceModuleBase, IModuleExtension
    {
        private IEnumerable<ISignalRClient> signalRClients;
        public const string MODULE_NAME = "SignalR_Module";

        public SignalRClientModule()
        {
            signalRClients = new List<ISignalRClient>();
        }

        public override string Name
        {
            get { return MODULE_NAME; }
        }

        public ServiceContext ServiceContext
        {
            get; set;
        }

        public override void Initialize()
        {
            base.Initialize();

            signalRClients = IocManager.Resolve<IEnumerable<ISignalRClient>>();
        }

        public override void Start()
        {
            foreach (var signalRClient in signalRClients)
            {
                signalRClient.Connect();
            }
        }

        public override void Stop()
        {
            foreach (var signalRClient in signalRClients)
            {
                signalRClient.Dispose();
            }
        }
    }
}
