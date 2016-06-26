using ImcFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImcFramework.Core.WcfService
{
    public class WcfServiceModule : ServiceModuleBase
    {
        public ServiceHost ServiceHost { get; private set; }

        public override string Name
        {
            get
            {
                return "WcfService";
            }
        }

        public override void Start()
        {
            TryCatchBlock.TrycatchAndLog(() =>
            {
                ServiceHost = new ServiceHost(typeof(ClientConnectorReal));
                //绑定服务行为
                ServiceMetadataBehavior behavior = ServiceHost.Description.Behaviors.
                    Find<ServiceMetadataBehavior>();
                {
                    if (behavior == null)
                    {
                        behavior = new ServiceMetadataBehavior();
                        behavior.HttpGetEnabled = true;
                        ServiceHost.Description.Behaviors.Add(behavior);
                    }
                    else
                    {
                        behavior.HttpGetEnabled = true;
                    }
                }

                //启动事件
                ServiceHost.Opened += delegate
                {
                    LogHelper.Info("Host-->终结点为：" + ServiceHost.Description.Endpoints.FirstOrDefault().Address);
                    LogHelper.Info("Host-->服务启动，开始监听：" + ServiceHost.Description.ConfigurationName);
                };

                Thread th = new Thread(ServiceHost.Open);
                th.Start();
            });
        }

        public override void Stop()
        {
            if (ServiceHost != null)
            {
                try
                {
                    ServiceHost.Close();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
                finally
                {
                    ServiceHost.Abort();
                }
            }
        }
    }
}
