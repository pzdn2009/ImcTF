using ImcFramework.Core.SignalRExt.Client;
using ImcFramework.Core.WcfService;
using ImcFramework.Infrastructure;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using Microsoft.AspNet.SignalR.Client;
using System;

namespace ImcFramework.Core.SignalRExt
{
    public class ImcSignalR : SignalRClientBase
    {
        private string m_Mac;
        private IServiceTypeReader serviceTypeReader;

        public ImcSignalR(IIocManager iocManager, IServiceTypeReader serviceTypeReader) :
            base(iocManager)
        {
            this.SignalRClientConfig = new SignalRClientConfig()
            {
                HubName = "ImcServiceHub",
                ServerUrl = "http://localhost:59894/signalr"
            };

            this.serviceTypeReader = serviceTypeReader;
            m_Mac = MachineManager.GetMac();
        }

        public override AuthenticationType AuthenticationType
        {
            get { return AuthenticationType.None; }
        }

        protected override void OnConnected()
        {
            foreach (var serviceType in serviceTypeReader.GetEServiceTypes())
            {
                //HubProxy.Invoke("WinServiceRegister", serviceType, m_Mac, Defaults.ProcessName);
            }
        }

        public override void RegisterServerMethod()
        {
            try
            {
                HubProxy.On<string>("broadcastMessage", (message) =>
                {
                    LoggerPool.Log(Name, new LogPool.LogContentEntity() { Message = message });
                });
            }
            catch (AggregateException ex)
            {
                foreach (var exItem in ex.InnerExceptions)
                {
                    var msg = exItem.Message + exItem.GetType().ToString() + exItem.StackTrace;

                    LoggerPool.Log(Name, new LogContentEntity()
                    {
                        Level = "Error",
                        Message = msg
                    });
                }
            }
            catch (System.Exception ex)
            {
                var msg = string.Empty;

                LoggerPool.Log(Name, new LogContentEntity()
                {
                    Level = "Error",
                    Message = ex.Message + ex.StackTrace
                });
            }
        }
    }
}
