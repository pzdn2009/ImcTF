using ImcFramework.Infrastructure;
using ImcFramework.Core;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;

namespace ImcFramework.Core
{
    public class Host
    {
        public static ServiceHost HostService(Type concreteService)
        {
            ServiceHost thisHost = null;
            TryCatchBlock.TrycatchAndLog(() =>
            {
                thisHost = new ServiceHost(concreteService);
                //绑定服务行为
                ServiceMetadataBehavior behavior = thisHost.Description.Behaviors.
                    Find<ServiceMetadataBehavior>();
                {
                    if (behavior == null)
                    {
                        behavior = new ServiceMetadataBehavior();
                        behavior.HttpGetEnabled = true;
                        thisHost.Description.Behaviors.Add(behavior);
                    }
                    else
                    {
                        behavior.HttpGetEnabled = true;
                    }
                }

                //启动事件
                thisHost.Opened += delegate
                {
                    LogHelper.Info("Host-->终结点为：" + thisHost.Description.Endpoints.FirstOrDefault().Address);
                    LogHelper.Info("Host-->服务启动，开始监听：" + thisHost.Description.ConfigurationName);
                };

                Thread th = new Thread(thisHost.Open);
                th.Start();
            });

            return thisHost;
        }

        public static void Close(ServiceHost host)
        {
            try
            {
                host.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
            finally
            {
                host.Abort();
            }
        }
    }
}
