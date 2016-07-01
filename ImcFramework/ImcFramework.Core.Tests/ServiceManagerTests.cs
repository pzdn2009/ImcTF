using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImcFramework.WcfInterface;
using Quartz;
using Quartz.Impl;
using ImcFramework.Ioc;
using ImcFramework.Core.Quartz;
using ImcFramework.Core.LogModule;
using System.Reflection;
using System.Linq;
using ImcFramework.Core.WcfService;

namespace ImcFramework.Core.Tests
{
    [TestClass]
    public class ServiceManagerTests
    {
        private Assembly asm = null;
        private IIocManager ioc = null;

        #region 附加测试特性
        //在运行每个测试之前，使用 TestInitialize 来运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            asm = typeof(ServiceManager).Assembly;
            ioc = Ioc.IocManager.Instance;
        }

        //在每个测试运行完之后，使用 TestCleanup 来运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
            asm = null;
            ioc = null;
        }

        #endregion
       
        [TestMethod]
        public void register_asm_can_resolve_the_IServiceModule()
        {
            ioc.Register<ServiceContext>(DependencyLifeStyle.Singleton);
            ioc.RegisterAssemblyAsInterfaces(asm);

            var serviceModules = ioc.Resolve<IEnumerable<IServiceModule>>();
            foreach (var md in serviceModules)
            {
                Console.WriteLine(md.Name);
            }

            Assert.IsNotNull(serviceModules);
            Console.WriteLine(serviceModules.Count());
        }

        [TestMethod]
        public void register_asm_can_resolve_ICommandInvoker()
        {
            ioc.Register<ServiceContext>(DependencyLifeStyle.Singleton);
            ioc.RegisterAssemblyAsInterfaces(asm);

            var serviceModules = ioc.Resolve<IEnumerable<IServiceModule>>();
            foreach (var md in serviceModules)
            {
                md.IocManager = ioc;
                md.Initialize();
                if (md.Name == "Quartz") 
                {
                    md.Start();
                }
                Console.WriteLine(md.Name);
            }

            var cmdInvoker = ioc.Resolve<ICommandInvoker>();

            Assert.IsNotNull(cmdInvoker);
        }

        [TestMethod]
        public void register_asm_can_resolve_ILoggerPoolFactory()
        {
            ioc.Register<ServiceContext>(DependencyLifeStyle.Singleton);
            ioc.RegisterAssemblyAsInterfaces(asm);

            var serviceModules = ioc.Resolve<IEnumerable<IServiceModule>>();
            foreach (var md in serviceModules)
            {
                md.IocManager = ioc;
                md.Initialize();
                if (md.Name == "Quartz")
                {
                    md.Start();
                }
                Console.WriteLine(md.Name);
            }

            var logPool = ioc.Resolve<ILoggerPoolFactory>();

            Assert.IsNotNull(logPool);
        }

        [TestMethod]
        public void register_asm_can_resolve_IClientConnector()
        {
            ioc.Register<ServiceContext>(DependencyLifeStyle.Singleton);
            ioc.RegisterAssemblyAsInterfaces(asm);

            var serviceModules = ioc.Resolve<IEnumerable<IServiceModule>>();
            foreach (var md in serviceModules)
            {
                md.IocManager = ioc;
                md.Initialize();
                if (md.Name == "Quartz")
                {
                    md.Start();
                }
                Console.WriteLine(md.Name);
            }

            var wcf = ioc.Resolve<IClientConnector>();

            Assert.IsNotNull(wcf);
        }
    }
}
