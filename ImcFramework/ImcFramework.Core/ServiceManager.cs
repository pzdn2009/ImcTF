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
            ServiceContext.Scheduler = null;
            ServiceContext.WcfHost = null;
            ServiceContext.ProgressInfoManager = ProgressInfoManager.Instance;

            iocManager = IocManager.Instance;

            Initialize();
        }

        public static ServiceContext ServiceContext { get; set; }

        private static void Initialize()
        {
            iocManager.RegisterAssemblyAsInterfaces(typeof(ServiceManager).Assembly);

            //iocManager.Register<IServiceModule, StdQuartzModule>(DependencyLifeStyle.Singleton, false);
            //iocManager.Register<IServiceModule, WcfServiceModule>(DependencyLifeStyle.Singleton, false);

            buildInModules = iocManager.Resolve<IEnumerable<IServiceModule>>();
        }

        public static void StartAll()
        {
            foreach (var buidIn in buildInModules)
            {
                if (buidIn is IModuleExtension) continue;
                buidIn.IocManager = iocManager;
                buidIn.Initialize();
                buidIn.Start();
            }

            extensionModules = ModuleConfiguration.ReadConfig(ServiceContext);
            foreach (var item in extensionModules)
            {
                (item as IServiceModule).Start();
            }
        }

        public static void StopAll()
        {
            if (extensionModules != null)
            {
                foreach (var item in extensionModules)
                {
                    (item as IServiceModule).Stop();
                }
            }

            foreach (var buidIn in buildInModules.Reverse())
            {
                if (buidIn is IModuleExtension) continue;
                buidIn.Stop();
            }
        }
    }
}
