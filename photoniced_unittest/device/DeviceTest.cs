using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.device;
using Moq;
using photoniced.device.interfaces;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.interfaces;

namespace photoniced_unittest
{
    [TestClass]
    public class DeviceTest
    {
        [TestMethod]
        public void constructor_parser_test()
        {
            var reader = new Mock<IDeviceReader>().Object;
            var sorter = new Mock<IDeviceSorter>().Object;
            var changer = new Mock<IDeviceChanger>().Object;
            Assert.ThrowsException<ArgumentNullException>(() => new Device(null, reader, sorter, changer));
        }
        
        [TestMethod]
        public void constructor_reader_test()
        {
            var commandLine = new Mock<ICommandLineParser>().Object;
            var sorter = new Mock<IDeviceSorter>().Object;
            var changer = new Mock<IDeviceChanger>().Object;
            Assert.ThrowsException<ArgumentNullException>(() => new Device(commandLine, null, sorter, changer));
        }
        
        [TestMethod]
        public void constructor_sorter_test()
        {
            var commandLine = new Mock<ICommandLineParser>().Object;
            var reader = new Mock<IDeviceReader>().Object;
            var changer = new Mock<IDeviceChanger>().Object;
            Assert.ThrowsException<ArgumentNullException>(() => new Device(commandLine, reader, null, changer));
        }
        
        [TestMethod]
        public void constructor_changer_test()
        {
            var commandLine = new Mock<ICommandLineParser>().Object;
            var reader = new Mock<IDeviceReader>().Object;
            var sorter = new Mock<IDeviceSorter>().Object;
            Assert.ThrowsException<ArgumentNullException>(() => new Device(commandLine, reader, sorter, null));
        }

        [TestMethod]
        public void cmd_parser_dependency_test()
        {
            var commandLine = new Mock<ICommandLineParser>();
            var reader = new Mock<IDeviceReader>();
            var sorter = new Mock<IDeviceSorter>();
            var changer = new Mock<IDeviceChanger>();
            var dev = new Device(commandLine.Object, reader.Object, sorter.Object, changer.Object);
            Assert.AreSame(dev.CmdParser, commandLine.Object);
        }

        [TestMethod]
        public void init_reader_test()
        {
            var commandLine = new Mock<ICommandLineParser>();
            var reader = new Mock<IDeviceReader>();
            var sorter = new Mock<IDeviceSorter>();
            var changer = new Mock<IDeviceChanger>();
            var dev = new Device(commandLine.Object, reader.Object, sorter.Object, changer.Object);
            reader.Verify((m)=>m.set_parser(commandLine.Object), Times.Once);
        }
        
        [TestMethod]
        public void init_sorter_test()
        {
            var commandLine = new Mock<ICommandLineParser>();
            var reader = new Mock<IDeviceReader>();
            var sorter = new Mock<IDeviceSorter>();
            var changer = new Mock<IDeviceChanger>();
            var dev = new Device(commandLine.Object, reader.Object, sorter.Object, changer.Object);
            sorter.Verify((m)=>m.set_parser(commandLine.Object), Times.Once);
        }
        
        [TestMethod]
        public void init_changer_test()
        {
            var commandLine = new Mock<ICommandLineParser>();
            var reader = new Mock<IDeviceReader>();
            var sorter = new Mock<IDeviceSorter>();
            var changer = new Mock<IDeviceChanger>();
            var dev = new Device(commandLine.Object, reader.Object, sorter.Object, changer.Object);
            changer.Verify((m)=>m.set_parser(commandLine.Object), Times.Once);
        }

        [TestMethod]
        public void read_test()
        {
            var commandLine = new Mock<ICommandLineParser>();
            var reader = new Mock<IDeviceReader>();
            var sorter = new Mock<IDeviceSorter>();
            var changer = new Mock<IDeviceChanger>();
            var dev = new Mock<Device>(new object[]{commandLine.Object, reader.Object, sorter.Object, changer.Object});
            dev.Object.read();
            reader.Verify((m)=>m.read(), Times.Once);
        }

        [TestMethod]
        public void sort_test()
        {
            var commandLine = new Mock<ICommandLineParser>();
            var reader = new Mock<IDeviceReader>();
            var sorter = new Mock<IDeviceSorter>();
            var changer = new Mock<IDeviceChanger>();
            var dev = new Mock<Device>(new object[]{commandLine.Object, reader.Object, sorter.Object, changer.Object});
            dev.Object.sort();
            sorter.Verify((m)=>m.sort(), Times.Once);
        }

        [TestMethod]
        public void change_test()
        {
            var commandLine = new Mock<ICommandLineParser>();
            var reader = new Mock<IDeviceReader>();
            var sorter = new Mock<IDeviceSorter>();
            var changer = new Mock<IDeviceChanger>();
            var dev = new Mock<Device>(new object[]{commandLine.Object, reader.Object, sorter.Object, changer.Object});
            dev.Object.change_device_path();
            changer.Verify((m)=>m.change(), Times.Once);
        }
    }
}
