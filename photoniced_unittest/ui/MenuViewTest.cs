using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.device.interfaces;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.interfaces;
using photoniced.repos;
using photoniced.ui;

namespace photoniced_unittest.ui
{
    [TestClass]
    public class MenuViewTest
    {
        [TestMethod]
        public void constructor_test()
        {
            //var commandLine = new Mock<ICommandLineParser>().Object;
            //var reader = new Mock<IDeviceReader>().Object;
            //var sorter = new Mock<IDeviceSorter>().Object;
           // var changer = new Mock<IDeviceChanger>().Object;
           // var dev = new Mock<Device>(new object[]{commandLine, reader, sorter, changer});
            
          //  var view = new MenuView(new string[0], 0, MenuBuilder.get_methods(dev.Object), "./");
          //  Mock.Get(view).Verify((m)=>m.render(), Times.Once);
        }
        [TestMethod]
        public void constructor_null_test()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new MenuView(new string[]{""}, 0, null, "/test"));
            Assert.ThrowsException<ArgumentNullException>(() => new MenuView(new string[]{""}, 0, new List<MethodsHolder>(), null));
        }

        [TestMethod]
        public void configure_test()
        {
            
        }

        [TestMethod]
        public void build_test()
        {
            
        }

        [TestMethod]
        public void show_test()
        {
            
        }
    }
}