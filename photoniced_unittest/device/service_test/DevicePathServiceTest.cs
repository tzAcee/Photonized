using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.device.services;

namespace photoniced_unittest.device.service_test
{
    [TestClass]
    public class DevicePathServiceTest
    {
        [TestMethod]
        public void path_valid_null_test()
        {
            Assert.AreEqual(false, DevicePathService.path_valid(null));
        }

        [TestMethod]
        public void path_valid_true_test()
        {
            Assert.AreEqual(true, DevicePathService.path_valid("./"));
        }

        [TestMethod]
        public void get_file_exception_test()
        {
            Assert.ThrowsException<InvalidDataException>(() => DevicePathService.get_file(null));
        }

        [TestMethod]
        public void get_file_test()
        {
            const string path = "./sa";
            Assert.AreEqual(new FileInfo(path).Name, DevicePathService.get_file(path).Name);
        }
    }
}