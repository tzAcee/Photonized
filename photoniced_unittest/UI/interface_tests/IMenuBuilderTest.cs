using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.essentials;
using photoniced.ui.repos;

namespace photoniced_unittest.UI.interface_tests
{
    [TestClass]
    public class IMenuBuilderTest
    {
        [TestMethod]
        public void get_lvl_test()
        {
            var obj = IMenuBuilder.get_lvl();
            Assert.AreEqual(obj, 0);
        }

        [TestMethod]
        public void get_args_test()
        {
            var obj = IMenuBuilder.get_args();
            Assert.AreEqual(0, obj.Length);
        }

        [TestMethod]
        public void get_methods_test()
        {
            var obj = IMenuBuilder.get_methods(null);
            Assert.AreEqual(0, obj.Count);
        }
    }
}