using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.device.services;

namespace photoniced_unittest.device.service_test
{
    [TestClass]
    public class DeviceNoteServiceTest
    {
        [TestMethod]
        public void get_file_path_null_test()
        {
            Assert.AreEqual(null, DeviceNoteService.get_file_path(null, false));
        }

        [TestMethod]
        public void get_file_path_create_test()
        {
            var file = DeviceNoteService.get_file_path("./", true);
            if (File.Exists(file))
            {
                File.Delete(file);
                return;
            }
            Assert.Fail();

        }

        [TestMethod]
        public void get_file_path_test()
        {
            const string path = "./";
            Assert.AreEqual(DevicePathService.get_file(path).FullName+".photon.json", DeviceNoteService.get_file_path(path, false));
        }

        [TestMethod]
        public void add_entry_test()
        {
            // TODO
        }

        [TestMethod]
        public void delete_entry_test()
        {
            // TODO
        }

        [TestMethod]
        public void read_entries_test()
        {
            // TODO
        }
    }
}