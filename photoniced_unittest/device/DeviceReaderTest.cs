using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.device.interfaces;
using photoniced.essentials;
using photoniced.essentials.commandline_parser.interfaces;
using photoniced.essentials.ConsoleUnitWrapper;

namespace photoniced_unittest.device
{
    [TestClass]
    public class DeviceReaderTest
    {
        [TestMethod]
        public void set_parser_test()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new DeviceReader(null));
        }

        [TestMethod]
        public void set_parser_valid_test()
        {
            var console = new Mock<IConsole>();
            var parser = new Mock<ICommandLineParser>();
            var reader = new DeviceReader(console.Object);
            reader.set_parser(parser.Object);
        }

        [TestMethod]
        public void delete_null_test()
        {
            var console = new Mock<IConsole>();
            var reader = new DeviceReader(console.Object);
            Assert.ThrowsException<NullReferenceException>(()=>reader.delete());

        }

        [TestMethod]
        public void read_call_structure_test()
        {

            var parser = new Mock<ICommandLineParser>();
            var console = new Mock<IConsole>();
            var reader = new DeviceReader(console.Object);
            reader.set_parser(parser.Object);

            console.Setup(fun => fun.Clear());
            console.Setup(fun => fun.WriteLine("Device Structure: (Any Key to continue)"));
            console.Setup(fun => fun.ReadLine()).Returns("");

            reader.read();

            console.VerifyAll();

        }

        [TestMethod]
        public void print_structure_simple_test()
        {
            var parser = new Mock<ICommandLineParser>();
            var console = new Mock<IConsole>();
            var reader = new DeviceReader(console.Object);
            reader.set_parser(parser.Object);

            console.Setup(fun => fun.Clear());
            console.Setup(fun => fun.WriteLine("Device Structure: (Any Key to continue)"));
            console.Setup(fun => fun.ReadLine()).Returns("");

            reader.print_structure();

            console.VerifyAll();
        }
    }
}