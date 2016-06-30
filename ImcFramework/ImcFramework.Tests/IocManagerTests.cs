using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImcFramework.Ioc;

namespace ImcFramework.Tests
{
    [TestClass]
    public class IocManagerTests
    {
        [TestMethod]
        public void contructor_should_make_an_not_null_instance()
        {
            var instance = IocManager.Instance;

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void iocmanager_should_be_single_ton()
        {
            var ins1 = IocManager.Instance;
            var ins2 = IocManager.Instance;

            Assert.AreEqual(ins1, ins2);
        }

        [TestMethod]
        public void iocManager_can_resolve_self()
        {
            var ins1 = IocManager.Instance;

            var ins2 = IocManager.Instance.Resolve<IIocManager>();

            Assert.AreEqual(ins1, ins2);
        }

        [TestMethod]
        public void iocmanager_can_resolve_singleton_instance_self()
        {
            var ins1 = IocManager.Instance.Resolve<IIocManager>();
            var ins2 = IocManager.Instance.Resolve<IIocManager>();

            Assert.AreEqual(ins1, ins2);
        }

        [TestMethod]
        public void iocmanager_can_resolve_singleton_instance()
        {
            IocManager.Instance.Register<IUser, UserA>(DependencyLifeStyle.Singleton);
            var ins1 = IocManager.Instance.Resolve<IUser>();
            var ins2 = IocManager.Instance.Resolve<IUser>();    

            Assert.AreEqual(ins1, ins2);
            Assert.AreEqual(ins1.Name, ins2.Name);
        }

        [TestMethod]
        public void iocmanager_can_resolve_perDependency_instance()
        {
            IocManager.Instance.Register<IUser, UserA>(DependencyLifeStyle.Transient);
            var ins1 = IocManager.Instance.Resolve<IUser>();
            var ins2 = IocManager.Instance.Resolve<IUser>();

            Assert.AreNotEqual(ins1, ins2);
            Assert.AreEqual(ins1.Name, ins2.Name);
        }

        [TestMethod]
        public void iocmanager_can_register_usera_userb()
        {
            IocManager.Instance.Register<IUser, UserA>(DependencyLifeStyle.Transient);
            IocManager.Instance.Register<IUser, UserB>(DependencyLifeStyle.Transient);

            var ins1 = IocManager.Instance.Resolve<IUser>();
            var ins2 = IocManager.Instance.Resolve<IUser>();

            Assert.AreNotEqual(ins1, ins2);
            Assert.AreEqual(ins1.Name, ins2.Name);
        }
    }

    public interface IUser
    {
        string Name { get; }
    }

    public class UserA : IUser
    {
        public string Name
        {
            get
            {
                return "pzdn2009";
            }
        }
    }

    public class UserB:IUser
    {
        public string Name
        {
            get { return "danna"; }
        }
    }
}
