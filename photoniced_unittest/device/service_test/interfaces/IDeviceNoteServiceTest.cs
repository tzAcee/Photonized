using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.device.interfaces.services;
using photoniced.essentials;

namespace photoniced_unittest.device.service_test.interfaces
{
    [TestClass]
    public class IDeviceNoteServiceTest
    {
        [TestMethod]
        public void get_file_path_test()
        {
            Assert.AreEqual(null, IDeviceNoteService.get_file_path("./"));
        }

        [TestMethod]
        public void add_entry_test()
        {
            Assert.ThrowsException<NotImplementedException>(() => IDeviceNoteService.add_entry("./", 
                new DeviceUserEntry("null", "null", new DateTime(2020,2,12))));
        }

        [TestMethod]
        public void delete_entry_test()
        {
            Assert.ThrowsException<NotImplementedException>(() => IDeviceNoteService.delete_entry("./", 
                new DeviceUserEntry("null", "null", new DateTime(2020,2,12))));
        }

        [TestMethod]
        public void read_entries_test()
        {
            Assert.AreEqual(null, IDeviceNoteService.read_entries("./"));
        }
    }
}