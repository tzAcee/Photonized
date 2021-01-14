using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.device.interfaces;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.essentials.ConsoleUnitWrapper;

namespace photoniced_unittest.device
{
    [TestClass]
    public class DeviceChangerTest
    {

        [TestMethod]
        public void set_parser_null_test()
        {
            var console = new Mock<IConsole>();
            var changer = new Mock<DeviceChanger>(console.Object);
            Assert.ThrowsException<ArgumentNullException>(() => changer.Object.set_parser(null));
        }

        [TestMethod]
        public void set_parser_valid_test()
        {
            var console = new Mock<IConsole>();
            var parser = new Mock<ICommandLineParser>();

            var changer = new DeviceChanger(console.Object);
            changer.set_parser(parser.Object);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void change_write_test()
        {
            var console = new Mock<IConsole>();
            console.Setup(func => func.Write("Paste your new path: "));
            console.Setup(func => func.ReadLine()).Returns("./");
            var parser = new Mock<ICommandLineParser>();

            var changer = new DeviceChanger(console.Object);
            changer.set_parser(parser.Object);

 

            changer.change();

            console.VerifyAll();
        }

        [TestMethod]
        public void change_exception_test()
        {
            var console = new Mock<IConsole>();
            
            var parser = new Mock<ICommandLineParser>();

            var changer = new DeviceChanger(console.Object);
            changer.set_parser(parser.Object);

            Assert.ThrowsException<ArgumentNullException>(() => changer.change());

           // console.VerifyAll();
        }
    }
}