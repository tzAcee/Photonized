using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.device.interfaces;


namespace photoniced_unittest.device
{
    [TestClass]
    public class DeviceChangerTest
    {

        [TestMethod]
        public void set_parser_test()
        {
            var changer = new Mock<DeviceChanger>();
            Assert.ThrowsException<ArgumentNullException>(() => changer.Object.set_parser(null));
        }

        [TestMethod]
        public void change_test()
        {
            // TODO
        }
    }
}