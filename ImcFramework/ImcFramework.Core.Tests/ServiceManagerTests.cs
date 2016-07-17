using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImcFramework.WcfInterface;
using Quartz;
using Quartz.Impl;
using ImcFramework.Ioc;
using ImcFramework.Core.Quartz;
using System.Reflection;
using System.Linq;
using ImcFramework.Core.WcfService;
using Moq;
using System.ServiceModel;
using ImcFramework.LogPool;
using ImcFramework.Core.Distribution;
using ImcFramework.WcfInterface.TransferMessage;
using ImcFramework.Core.MqModuleExtension;

namespace ImcFramework.Core.Tests
{
    [TestClass]
    public class ServiceManagerTests
    {
        private Assembly asm = null;
        private IIocManager ioc = null;

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

        [TestMethod]
        public void register_asm_can_resolve_the_IServiceModule()
        {
            ioc.RegisterAssemblyAsInterfaces(typeof(ILoggerPoolFactory).Assembly);
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
        public void register_asm_can_resolve_the_IModuleExtension()
        {
            ioc.RegisterAssemblyAsInterfaces(asm);

            var serviceModules = ioc.Resolve<IEnumerable<IModuleExtension>>();
            foreach (var md in serviceModules)
            {
                Console.WriteLine(md.GetType().ToString());
            }

            Assert.IsNotNull(serviceModules);
            Console.WriteLine(serviceModules.Count());
        }

        [TestMethod]
        public void register_asm_can_resolve_ICommandInvoker()
        {
            ioc.RegisterAssemblyAsInterfaces(asm);

            Mock<IScheduler> moq = new Mock<IScheduler>();
            ioc.Register<IScheduler>(moq.Object);// 依赖于IScheduler，由于没有启动ISchedule，则不会有，故mock一个。

            var cmdInvoker = ioc.Resolve<ICommandInvoker>();

            Assert.IsNotNull(cmdInvoker);
        }

        [TestMethod]
        public void register_asm_can_resolve_ILoggerPoolFactory()
        {
            ioc.RegisterAssemblyAsInterfaces(asm);

            var logPool = ioc.Resolve<ILoggerPoolFactory>();

            Assert.IsNotNull(logPool);
        }

        [TestMethod]
        public void register_asm_can_resolve_IClientConnector()
        {
            ioc.RegisterAssemblyAsInterfaces(asm);

            var wcf = ioc.Resolve<IClientConnector>();

            Assert.IsNotNull(wcf);
        }

        [TestMethod]
        public void register_asm_can_resolve_IIDistributionFacility_T()
        {
            ioc.RegisterAssemblyAsInterfaces(asm);
            ioc.RegisterGeneric(typeof(MsmqDistribution<>), typeof(IDistributionFacility<>));

            var mq = ioc.Resolve<IDistributionFacility<MessageEntity>>();

            Assert.IsNotNull(mq);
        }
    }
}
