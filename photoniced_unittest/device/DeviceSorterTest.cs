using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.essentials.ConsoleUnitWrapper;
using photoniced.interfaces;

namespace photoniced_unittest.device
{
    [TestClass]
    public class DeviceSorterTest
    {
        [TestMethod]
        public void set_parser_test()
        {
            var reader = new Mock<DeviceSorter>();
            Assert.ThrowsException<ArgumentNullException>(() => reader.Object.set_parser(null));
        }

        [TestMethod]
        public void get_user_entry_test()
        {
            var console = new Mock<IConsole>();

            console.Setup(item => item.WriteLine("Hallo welt"));

            console.Setup(func => func.ReadLine()).Returns("hallo");

            var sorter = new DeviceSorter(console.Object);

            console.Object.WriteLine("Hallo welt111");

            console.VerifyAll();
        }

        [TestMethod]
        public void sort()
        {
            // TODO
        }
    }
}