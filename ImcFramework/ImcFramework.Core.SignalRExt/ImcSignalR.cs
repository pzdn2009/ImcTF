using ImcFramework.Core.SignalRExt.Client;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using Microsoft.AspNet.SignalR.Client;
using System;

namespace ImcFramework.Core.SignalRExt
{
    public class ImcSignalR : SignalRClientBase
    {
        public ImcSignalR(IIocManager iocManager) :
            base(iocManager)
        {
            this.SignalRClientConfig = new SignalRClientConfig()
            {
                HubName = "ImcServiceHub",
                ServerUrl = "http://localhost:59894/signalr"
            };
        }

        public override AuthenticationType AuthenticationType
        {
            get { return AuthenticationType.None; }
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
                    var msg =  exItem.Message + exItem.GetType().ToString() + exItem.StackTrace;

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
