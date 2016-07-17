using ImcFramework.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImcFramework.Core.WcfService;

namespace ImcFramework.Core.Tests
{
    [TestClass]
    public class GlobalRegisterTests
    {
        [TestMethod]
        public void Global_register_can_resolve_MyLogin()
        {
            ServiceManager.Initialize();

            var login = IocManager.Instance.Resolve<ILogin>();
            var ret = login.Login("pzdn2009", "***");
            Assert.AreEqual(false, ret);
        }
    }

    public class MyGlobalRegister : IGlobalRegister
    {
        public void Register(IIocManager iocManager)
        {
            iocManager.Register<ILogin, MyLogin>();
        }
    }

    public class MyLogin : ILogin
    {
        public bool Login(string userName, string password)
        {
            if (userName == "pzdn2009") return false;
            return true;
        }
    }
}
