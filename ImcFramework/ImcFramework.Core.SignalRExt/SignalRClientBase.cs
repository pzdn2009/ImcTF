using ImcFramework.Core.SignalRExt.Client;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace ImcFramework.Core.SignalRExt
{
    /// <summary>
    /// Ref:http://www.asp.net/signalr/overview/guide-to-the-api/hubs-api-guide-net-client#clientcertificate
    /// </summary>
    public abstract class SignalRClientBase : ISignalRClient
    {
        private HubConnection connection;

        public IHubProxy HubProxy { get; set; }
        public SignalRClientConfig SignalRClientConfig { get; set; }
        public IIocManager IocManager { get; set; }
        public ILoggerPool LoggerPool { get; set; }

        public abstract AuthenticationType AuthenticationType { get; }

        public string Name
        {
            get
            {
                return SignalRClientConfig.HubName;
            }
        }

        public abstract void RegisterServerMethod();

        public SignalRClientBase(IIocManager iocManager)
        {
            IocManager = iocManager;
            LoggerPool = IocManager.Resolve<ILoggerPool>(SignalRClientModule.MODULE_NAME);
        }

        #region 连接

        public void Connect()
        {
            try
            {
                ConnectAsync();
            }
            catch (AggregateException ex)
            {
                foreach (var exItem in ex.InnerExceptions)
                {
                    LoggerPool.Log(Name, new LogContentEntity()
                    {
                        Level = "Error",
                        Message = exItem.Message + exItem.StackTrace
                    });
                }
            }
            catch (Exception ex)
            {
                LoggerPool.Log(Name, new LogContentEntity()
                {
                    Level = "Error",
                    Message = ex.Message + ex.StackTrace
                });
            }
        }

        private async void ConnectAsync()
        {
            connection = new HubConnection(SignalRClientConfig.ServerUrl);

            switch (AuthenticationType)
            {
                case AuthenticationType.None:
                    break;
                case AuthenticationType.Cookie:
                    Cookie returnedCookie;
                    var authResult = SignalRClientConfig.CookieAuthenticate.AuthenticateUser(out returnedCookie);
                    if (authResult)
                    {
                        connection.CookieContainer = new CookieContainer();
                        connection.CookieContainer.Add(returnedCookie);
                    }
                    else
                    {
                        Console.WriteLine("Login failed");
                    }
                    break;
                case AuthenticationType.Windows:
                    connection.Credentials = CredentialCache.DefaultCredentials;
                    break;
                case AuthenticationType.Token:
                    connection.Headers.Add(SignalRClientConfig.TokenData.Name, SignalRClientConfig.TokenData.Token);
                    break;
                case AuthenticationType.Certificate:
                    connection.AddClientCertificate(X509Certificate.CreateFromCertFile(SignalRClientConfig.CertificateName));
                    break;
                default:
                    break;
            }

            connection.Closed += Connection_Closed;
            connection.Reconnected += Connection_Reconnected;

            HubProxy = connection.CreateHubProxy(SignalRClientConfig.HubName);

            RegisterServerMethod();

            try
            {
                await connection.Start().ContinueWith((t) =>
                {
                    if (t.IsFaulted)
                    {
                        foreach (var exItem in t.Exception.InnerExceptions)
                        {
                            var msg = exItem.Message + exItem.GetType().ToString() + exItem.StackTrace;

                            LoggerPool.Log(Name, new LogContentEntity()
                            {
                                Level = "Error",
                                Message = msg
                            });
                        }
                    }
                    else
                    {
                        LoggerPool.Log(SignalRClientConfig.HubName, new LogContentEntity()
                        {
                            Level = "Info",
                            Message = "Connect success"
                        });
                    }
                });
            }
            catch (HttpRequestException ex)
            {
                var msg = "Unable to connect to server: Start server before connecting clients.";

                LoggerPool.Log(SignalRClientConfig.HubName, new LogContentEntity()
                {
                    Level = "Error",
                    Message = msg + ex.Message + ex.StackTrace
                });
            }
        }

        #endregion

        #region Events

        public virtual void Connection_Closed()
        {
            string msg = "You have been disconnected.";

            LoggerPool.Log(SignalRClientConfig.HubName, new LogContentEntity()
            {
                Level = "Info",
                Message = msg
            });
        }

        public virtual void Connection_Reconnected()
        {
            string msg = "You have been Reconnected.";

            LoggerPool.Log(SignalRClientConfig.HubName, new LogContentEntity()
            {
                Level = "Info",
                Message = msg
            });
        }

        #endregion

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Stop();
                connection.Dispose();
            }
        }
    }
}
