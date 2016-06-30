using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ImcFramework.Tests
{
    [TestClass]
    public class AutofacTests
    {
        private ContainerBuilder builder;
        private IContainer container;

        [TestMethod]
        public void register_many_instances_of_an_interface()
        {
            builder = new ContainerBuilder();
            builder.RegisterType<UserA>().As<IUser>();
            builder.RegisterType<UserB>().As<IUser>().PreserveExistingDefaults();

            container = builder.Build();

            var instances = container.Resolve<IEnumerable<IUser>>();
            Assert.AreEqual(2, instances.Count());

            foreach (var ins in instances)
            {
                Console.WriteLine(ins.Name);
            }
        }

        [TestMethod]
        public void register_module_test()
        {
            builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            container = builder.Build();

            var instances = container.Resolve<IEnumerable<IUser>>();
            Assert.AreEqual(2, instances.Count());
        }
    }
}
