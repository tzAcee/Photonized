using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.interfaces;

namespace photoniced_unittest.device
{
    [TestClass]
    public class DeviceSorterTest
    {
        [TestMethod]
        public void set_parser_test()
        {
            var reader = new Mock<DeviceSorter>();
            Assert.ThrowsException<ArgumentNullException>(() => reader.Object.set_parser(null));
        }

        [TestMethod]
        public void get_user_entry_test()
        {
            // TODO
        }

        [TestMethod]
        public void sort()
        {
            // TODO
        }
    }
}