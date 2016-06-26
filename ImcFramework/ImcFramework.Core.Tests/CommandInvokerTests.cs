using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImcFramework.WcfInterface;
using ImcFramework.Core.Quartz;

namespace ImcFramework.Core.Tests
{
    [TestClass]
    public class CommandInvokerTests
    {
        [TestMethod]
        public void Test()
        {
            var type = CommandInvoker.GetCommandClass(ECommand.GetServiceInfo);
            Assert.IsNotNull(type);
        }
    }
}
