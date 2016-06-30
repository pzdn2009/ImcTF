using System.Collections.Generic;
using ImcFramework.Core.Quartz;
using ImcFramework.Core.WcfService;
using ImcFramework.Ioc;
using System.Linq;

namespace ImcFramework.Core
{
    /// <summary>
    /// 服务启动
    /// </summary>
    public static class ServiceManager
    {
        private static IEnumerable<IModuleExtension> extensionModules;
        private static IEnumerable<IServiceModule> buildInModules;

        private static IIocManager iocManager = null;

        static ServiceManager()
        {
            ServiceContext = new ServiceContext();

            iocManager = IocManager.Instance;

            Initialize();
        }

        public static ServiceContext ServiceContext { get; set; }

        private static void Initialize()
        {
            iocManager.Register<IServiceModule, StdQuartzModule>(DependencyLifeStyle.Singleton, false);
            iocManager.Register<IServiceModule, WcfServiceModule>(DependencyLifeStyle.Singleton, false);

            buildInModules = iocManager.Resolve<IEnumerable<IServiceModule>>();
        }

        public static void StartAll()
        {
            foreach (var buidIn in buildInModules)
            {
                buidIn.IocManager = iocManager;
                buidIn.Initialize();
                buidIn.Start();
            }

            ServiceContext.Scheduler = null;
            ServiceContext.WcfHost = null;
            ServiceContext.ProgressInfoManager = ProgressInfoManager.Instance;

            extensionModules = ModuleConfiguration.ReadConfig(ServiceContext);
            foreach (var item in extensionModules)
            {
                item.Start();
            }
        }

        public static void StopAll()
        {
            if (extensionModules != null)
            {
                foreach (var item in extensionModules)
                {
                    item.Stop();
                }
            }

            foreach (var buidIn in buildInModules.Reverse())
            {
                buidIn.Stop();
            }
        }
    }
}
