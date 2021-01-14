using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device;
using photoniced.essentials;
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
            var console = new Mock<IConsole>();
            var reader = new Mock<DeviceSorter>(console.Object);
            Assert.ThrowsException<ArgumentNullException>(() => reader.Object.set_parser(null));
        }

        [TestMethod]
        public void get_user_entry_intro_test()
        {
            var console = new Mock<IConsole>();
            console.Setup(item => item.WriteLine("For which day you want to sort the pictures? (DD/MM/YYYY)"));
            console.Setup(func => func.ReadLine()).Returns("12/03/2222");


            var sorter = new DeviceSorter(console.Object);
            sorter.get_user_entry();

            console.VerifyAll();
        }

        [TestMethod]
        public void get_user_entry_name_test()
        {
            var console = new Mock<IConsole>();
            console.Setup(item => item.WriteLine("For which day you want to sort the pictures? (DD/MM/YYYY)"));
            console.Setup(func => func.ReadLine()).Returns("12/03/2222");
            console.Setup(item => item.WriteLine("What did you do @ this day?"));

            var sorter = new DeviceSorter(console.Object);
            sorter.get_user_entry();

            console.VerifyAll();
        }

        [TestMethod]
        public void get_user_entry_description_test()
        {
            var console = new Mock<IConsole>();
            console.Setup(item => item.WriteLine("For which day you want to sort the pictures? (DD/MM/YYYY)"));
            console.Setup(func => func.ReadLine()).Returns("12/03/2222");
            console.Setup(item => item.WriteLine("What did you do @ this day?"));
            console.Setup(item => item.WriteLine("Give a little description for this day."));

            var sorter = new DeviceSorter(console.Object);
            sorter.get_user_entry();

            console.VerifyAll();
        }

        [TestMethod]
        public void get_user_entry_return_test()
        {
            var console = new Mock<IConsole>();
            console.SetupSequence(func => func.ReadLine())
                .Returns("12/03/2222")
                .Returns("test_name")
                .Returns("test_description");

            var sorter = new DeviceSorter(console.Object);

            DateTime parsedTime = new DateTime(2222, 03, 12);

            Assert.AreEqual(new DeviceUserEntry("test_name", "test_description", parsedTime), sorter.get_user_entry());

        }

        [TestMethod]
        public void get_user_entry_split_null_test()
        {
            var console = new Mock<IConsole>();;
            var sorter = new DeviceSorter(console.Object);

            Assert.ThrowsException<NullReferenceException>(() => sorter.get_user_entry());
        }

        [TestMethod]
        public void sort()
        {
            // TODO
        }
    }
}