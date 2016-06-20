using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.SignalRExt
{
    public class SignalRClient : IDisposable
    {
        //网址
        private readonly string m_ServerURI;
        //hub名称
        private readonly string m_HubName;

        //服务类型
        private string ServiceType { get; set; }
        //代理
        private IHubProxy HubProxy { get; set; }
        //连接
        private HubConnection m_Connection { get; set; }
        // 机器地址
        private string m_Mac { get; set; }

        public SignalRClient(string serverUrl, string hubName, string serviceType)
        {
            Guard.IsNull(serverUrl);
            Guard.IsNull(hubName);

            m_ServerURI = serverUrl;
            m_HubName = hubName;
            m_Mac = MachineManager.GetMac();

            ServiceType = serviceType;
        }

        #region 连接

        public void Connect()
        {
            try
            {
                ConnectAsync();
                Task.Factory.StartNew(() => SendHeart());
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + ex.StackTrace);
            }
        }

        private async void ConnectAsync()
        {
            m_Connection = new HubConnection(m_ServerURI);
            m_Connection.Closed += Connection_Closed;
            m_Connection.Reconnected += Connection_Reconnected;

            HubProxy = m_Connection.CreateHubProxy(m_HubName);

            RegisterMethods();

            try
            {
                await m_Connection.Start().ContinueWith((t) =>
                {
                    if (!t.IsFaulted)
                    {
                        //connect success ...
                    }
                    else
                    {
                        LogHelper.Error(t.Exception.Message + t.Exception.StackTrace);
                    }
                });
            }
            catch (HttpRequestException)
            {
                var msg = "Unable to connect to server: Start server before connecting clients.";
                LogHelper.Error(msg);
                return;
            }
        }

        #endregion

        private async void SendHeart()
        {
            while (true)
            {
                await Task.Delay(10000);

                if (m_Connection.State != ConnectionState.Connected) continue;

                var hb = HubProxy.Invoke("HeartBeat").ContinueWith<bool>(task =>
                     {
                         if (task.IsFaulted)
                         {
                             foreach (var ex in
                                      task.Exception.Flatten().InnerExceptions)
                             {
                                 LogHelper.Error("Error: " + ex.Message);
                             }
                             return false;
                         }
                         return true;
                     });

                if (!hb.Result)
                {
                    string msg = "HeartBeat Failed";
                    LogHelper.Info(msg);
                }
            }
        }

        public virtual void RegisterMethods()
        {
            HubProxy.On<string>("broadcastMessage", (message) =>
            {
                LogHelper.Info(message);
            });

            // add more registers here ...
        }

        #region Events

        public virtual void Connection_Closed()
        {
            string msg = "You have been disconnected.";
            LogHelper.Info(msg);
        }

        public virtual void Connection_Reconnected()
        {
            string msg = "You have been Reconnected.";
            LogHelper.Info(msg);
        }

        #endregion

        public void Dispose()
        {
            if (m_Connection != null)
            {
                m_Connection.Stop();
                m_Connection.Dispose();
            }
        }
    }
}
