using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.device.interfaces;

namespace photoniced_unittest.device
{
    [TestClass]
    public class DeviceReaderTest
    {
        [TestMethod]
        public void set_parser_test()
        {
            var reader = new Mock<DeviceReader>();
            Assert.ThrowsException<ArgumentNullException>(() => reader.Object.set_parser(null));
        }

        [TestMethod]
        public void read_test()
        {
            // TODO
        }
    }
}