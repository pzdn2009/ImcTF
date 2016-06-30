using System.Collections.Generic;
using ImcFramework.Core.Quartz;
using ImcFramework.Core.WcfService;
using ImcFramework.Ioc;

namespace ImcFramework.Core
{
    /// <summary>
    /// 服务启动
    /// </summary>
    public static class ServiceManager
    {
        private static IEnumerable<IModuleExtension> modules;
        private static IEnumerable<IServiceModule> buildInModules;
        private static StdQuartzModule stdQuartzModule;
        private static WcfServiceModule wcfServiceModule;

        private static IIocManager iocManager = null;

        static ServiceManager()
        {
            ServiceContext = new ServiceContext();

            iocManager = IocManager.Instance;
        }

        public static ServiceContext ServiceContext { get; set; }

        public static void StartAll()
        {
            wcfServiceModule = new WcfServiceModule();
            wcfServiceModule.IocManager = iocManager;
            wcfServiceModule.Initialize();
            
            wcfServiceModule.Start();

            stdQuartzModule = new StdQuartzModule();
            stdQuartzModule.IocManager = iocManager;
            stdQuartzModule.Initialize();
            
            stdQuartzModule.Start();

            ServiceContext.Scheduler = null;
            ServiceContext.WcfHost = wcfServiceModule.ServiceHost;
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
            wcfServiceModule.Stop();
        }
    }
}
