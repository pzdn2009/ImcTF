using System.Collections.Generic;
using System.Linq;

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

            try
            {
                signalRClients = IocManager.Resolve<IEnumerable<ISignalRClient>>();
            }
            catch (System.Exception ex)
            {
                LoggerPool.Log("", new LogPool.LogContentEntity()
                {
                    Level = "Error",
                    Message = ex.Message + ex.StackTrace
                });
            }
        }

        public override void Start()
        {
            foreach (var signalRClient in signalRClients)
            {
                signalRClient.Connect();

                LoggerPool.Log("", new LogPool.LogContentEntity()
                {
                    Level = "Info",
                    Message = signalRClient.Name + " call Connect();"
                });
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
