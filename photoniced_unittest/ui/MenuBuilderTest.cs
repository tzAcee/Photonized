using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.device.interfaces;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.interfaces;
using photoniced.ui;

namespace photoniced_unittest.ui
{
    [TestClass]
    public class MenuBuilderTest
    {
        
        [TestMethod]
        public void get_args_test()
        {
            int length = MenuBuilder.get_args().Length;
            Assert.AreEqual(0, length);   
        }
        [TestMethod]
        public void get_lvl_test()
        {
            int lvl = MenuBuilder.get_lvl();
            Assert.AreEqual(0, lvl);
        }
        [TestMethod]
        public void get_methods_count_test()
        {
            var commandLine = new Mock<ICommandLineParser>().Object;
            var reader = new Mock<IDeviceReader>().Object;
            var sorter = new Mock<IDeviceSorter>().Object;
            var changer = new Mock<IDeviceChanger>().Object;
            var dev = new Mock<Device>(new object[]{commandLine, reader, sorter, changer});

            var methods = MenuBuilder.get_methods(dev.Object);
            Assert.AreEqual(5, methods.Count);
        }

        [TestMethod]
        public void get_methods_not_null_test()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var tmp = MenuBuilder.get_methods(null);
            });
        }
        
    }
}