using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.device.interfaces.services;

namespace photoniced_unittest.device.service_test.interfaces
{
    [TestClass]
    public class IDevicePathServiceTest
    {
        [TestMethod]
        public void path_valid_test()
        {
            Assert.AreEqual(false, IDevicePathService.path_valid("./"));
        }

        [TestMethod]
        public void get_file_test()
        {
            Assert.AreEqual(null, IDevicePathService.get_file("./"));           
        }
    }
}