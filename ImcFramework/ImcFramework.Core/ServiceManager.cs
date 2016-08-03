using ImcFramework.Core.MutilUserProgress;
using ImcFramework.Core.Quartz;
using ImcFramework.Core.WcfService;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using ImcFramework.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ImcFramework.Core
{
    /// <summary>
    /// Service manager for the famework , which manages assmeblies registration and all modules's start / stop.
    /// </summary>
    public static class ServiceManager
    {
        private static IEnumerable<IModuleExtension> extensionModules;
        private static IEnumerable<IServiceModule> buildInModules;

        private static IIocManager iocManager = null;

        static ServiceManager()
        {
            iocManager = IocManager.Instance;

            Initialize();
        }

        /// <summary>
        /// Initialize assmeblies registration in order to register into the ioc container.
        /// </summary>
        internal static void Initialize()
        {
            var registeredAssmeblies = new HashSet<string>();

            var imcAsm = typeof(ILoggerPoolFactory).Assembly;
            iocManager.RegisterAssemblyAsInterfaces(imcAsm);
            registeredAssmeblies.Add(imcAsm.FullName);

            var assemblyFinder = iocManager.Resolve<IAssemblyFinder>();
            foreach (var asm in assemblyFinder.GetAllAssemblies().Union(assemblyFinder.GetAllBinDirectoryAssemblies()))
            {
                try
                {
                    if (registeredAssmeblies.Contains(asm.FullName)) continue;

                    var types = asm.GetExportedTypes();
                    foreach (var type in types)
                    {
                        if (type.Namespace.StartsWith(ImcFrameworkConstants.ImcFramework))
                        {
                            iocManager.RegisterAssemblyAsInterfaces(asm);
                            registeredAssmeblies.Add(asm.FullName);
                            break;
                        }
                    }
                }
                catch { }
            }

            //register the progressInfoManager as singleton
            iocManager.Register<IProgressInfoManager>(ProgressInfoManager.Instance);

            //load the Global Register & call the register method
            var gl = iocManager.Resolve<IEnumerable<IGlobalRegister>>();
            gl.ToList().ForEach(zw => { zw.Register(iocManager); });

            //resolve the modules
            buildInModules = iocManager.Resolve<IEnumerable<IServiceModule>>();
            extensionModules = iocManager.Resolve<IEnumerable<IModuleExtension>>();
        }

        /// <summary>
        /// Start all modules of the framework , includes build-in modules and extended modules.
        /// </summary>
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

            var serviceContext = new ServiceContext()
            {
                WcfHost = iocManager.Resolve<IServiceHostProvider>().ServiceHost,
                Scheduler = iocManager.Resolve<IScheduleProvider>().Schedule,
                ProgressInfoManager = iocManager.Resolve<IProgressInfoManager>()
            };

            foreach (var item in extensionModules)
            {
                item.ServiceContext = serviceContext;
                var svc = (item as IServiceModule);
                svc.IocManager = iocManager;
                svc.LoggerPool = loggerPoolFactory.GetLoggerPool(svc.Name);
                iocManager.Register<ILoggerPool>(svc.LoggerPool, svc.Name);

                svc.Initialize();
                svc.Start();
            }
        }

        /// <summary>
        /// Stop all modules of the framework , includes build-in modules and extended modules.
        /// </summary>
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
