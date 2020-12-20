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
        public void constructor_test()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Device(null, null, null, null));
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
    }
}
