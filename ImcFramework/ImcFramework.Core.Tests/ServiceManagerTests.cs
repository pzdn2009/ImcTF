using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImcFramework.WcfInterface;
using Quartz;
using Quartz.Impl;
using ImcFramework.Ioc;
using ImcFramework.Core.Quartz;

namespace ImcFramework.Core.Tests
{
    [TestClass]
    public class ServiceManagerTests
    {
        [TestMethod]
        public void StartAllTests()
        {
            ServiceManager.StartAll();
        }

        [TestMethod]
        public void register_asm_can_resolve_the_IServiceModule()
        {
            var asm = typeof(ServiceManager).Assembly;
            var ioc = Ioc.IocManager.Instance;

            ioc.Register<ISchedulerFactory, StdSchedulerFactory>(DependencyLifeStyle.Singleton);

            ioc.Register<ServiceContext>(Ioc.DependencyLifeStyle.Singleton);
            ioc.RegisterAssembly(asm);

            //Console.WriteLine(ioc.IsRegister<IScheduleProvider>());
            //return;

            var serviceModules = ioc.Resolve<IEnumerable<IServiceModule>>();
            foreach (var md in serviceModules)
            {
                md.Initialize();
                Console.WriteLine(md.Name);
            }
            Assert.IsNotNull(serviceModules);

            
            //var wcfSvc = ioc.Resolve<IScheduleProvider>();
            
        }
    }
}
