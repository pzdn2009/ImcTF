using System.Collections.Generic;
using ImcFramework.Ioc;
using System.Linq;
using ImcFramework.Core.MutilUserProgress;
using ImcFramework.LogPool;
using ImcFramework.Reflection;
using System;
using System.Reflection;
using System.IO;

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

            iocManager.Register<IProgressInfoManager>(ProgressInfoManager.Instance);

            //load the Global Register & call the register method
            var gl = iocManager.Resolve<IEnumerable<IGlobalRegister>>();
            gl.ToList().ForEach(zw => { zw.Register(iocManager); });

            //resolve the modules
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
