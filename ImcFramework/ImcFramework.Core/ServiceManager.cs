using System.Collections.Generic;
using ImcFramework.Ioc;
using System.Linq;
using ImcFramework.Core.MutilUserProgress;
using ImcFramework.LogPool;

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
            iocManager.RegisterAssemblyAsInterfaces(typeof(WcfInterface.TransferMessage.MessageEntity).Assembly);
            iocManager.RegisterAssemblyAsInterfaces(typeof(ILoggerPoolFactory).Assembly);
            iocManager.RegisterAssemblyAsInterfaces(typeof(ServiceManager).Assembly);

            buildInModules = iocManager.Resolve<IEnumerable<IServiceModule>>();
            extensionModules = iocManager.Resolve<IEnumerable<IModuleExtension>>();
        }

        public static void StartAll()
        {
            var loggerPoolFactory = iocManager.Resolve<ILoggerPoolFactory>();
            foreach (var buidIn in buildInModules)
            {
                if (buidIn is IModuleExtension) continue;
                buidIn.IocManager = iocManager;
                buidIn.LoggerPool = loggerPoolFactory.GetLoggerPool(buidIn.Name);
                iocManager.Register<ILoggerPool>(buidIn.LoggerPool, buidIn.Name);

                buidIn.Initialize();
                buidIn.Start();
            }

            foreach (var item in extensionModules)
            {
                item.ServiceContext = ServiceContext;
                var svc = (item as IServiceModule);
                svc.IocManager = iocManager;
                svc.LoggerPool = loggerPoolFactory.GetLoggerPool(svc.Name);
                iocManager.Register<ILoggerPool>(svc.LoggerPool, svc.Name);

                svc.Initialize();
                svc.Start();
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
