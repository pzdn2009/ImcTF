using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
