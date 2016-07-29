using System.Collections.Generic;
using ImcFramework.Ioc;
using System.Linq;
using ImcFramework.LogPool;
using ImcFramework.Reflection;

namespace ImcFramework.Core
{
    /// <summary>
    /// Service manager for the framework.
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

            //load the Global Register & call the register method
            var gl = iocManager.Resolve<IEnumerable<IGlobalRegister>>();
            gl.ToList().ForEach(zw => { zw.Register(iocManager); });

            //resolve the modules
            buildInModules = iocManager.Resolve<IEnumerable<IServiceModule>>();
            extensionModules = iocManager.Resolve<IEnumerable<IModuleExtension>>();
        }

        /// <summary>
        /// Start all modules which associated with the framework.
        /// </summary>
        public static void StartAll()
        {
            //start the build-in modules
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

            //buildInModules.ToList().ForEach(zw => zw.Start());

            //get the sevice context.
            var seviceContext = new ServiceContext();

            //start the extented modules
            foreach (var item in extensionModules)
            {
                item.ServiceContext = seviceContext;
                var svc = (item as IServiceModule);
                svc.IocManager = iocManager;
                svc.LoggerPool = loggerPoolFactory.GetLoggerPool(svc.Name);
                iocManager.Register<ILoggerPool>(svc.LoggerPool, svc.Name);

                svc.Initialize();
                svc.Start();
            }

            //extensionModules.ToList().ForEach(zw => (zw as IServiceModule).Start());
        }

        /// <summary>
        /// Stop all modules which associated with the framework.
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
