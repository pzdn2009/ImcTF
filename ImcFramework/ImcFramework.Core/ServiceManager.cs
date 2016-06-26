using ImcFramework.WcfInterface;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ImcFramework.Core.IsolatedAd;
using ImcFramework.Core.Quartz;

namespace ImcFramework.Core
{
    /// <summary>
    /// 服务启动
    /// </summary>
    public static class ServiceManager
    {
        private static ServiceHost hostStub;
        private static IEnumerable<IModuleExtension> modules;
        private static IEnumerable<IServiceModule> buildInModules;
        private static StdQuartzModule stdQuartzModule;

        static ServiceManager()
        {
            ServiceContext = new ServiceContext();
        }

        public static ServiceContext ServiceContext { get; set; }

        public static void StopWcfHost()
        {
            if (hostStub != null)
                Host.Close(hostStub);
        }

        public static void StartWcfHost()
        {
            hostStub = Host.HostService(typeof(ClientConnectorReal)); //寄宿
        }

        public static void StartAll()
        {
            StartWcfHost();

            stdQuartzModule = new StdQuartzModule();
            stdQuartzModule.Start();

            ServiceContext.Scheduler = stdQuartzModule.Scheduler;
            ServiceContext.WcfHost = hostStub;
            ServiceContext.ProgressInfoManager = ProgressInfoManager.Instance;

            modules = ModuleConfiguration.ReadConfig(ServiceContext);
            foreach (var item in modules)
            {
                item.Start();
            }
        }

        public static void StopAll()
        {
            if (modules != null)
            {
                foreach (var item in modules)
                {
                    item.Stop();
                }
            }

            stdQuartzModule.Stop();

            StopWcfHost();
        }
    }
}
