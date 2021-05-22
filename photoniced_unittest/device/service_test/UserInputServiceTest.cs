using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.device.services;
using photoniced.essentials;
using photoniced.essentials.ConsoleUnitWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced_unittest.device.service_test
{
    [TestClass]
    public class UserInputServiceTest
    {
        [TestMethod]
        public void get_user_entry_intro_test()
        {
            var console = new Mock<IConsole>();
            console.Setup(item => item.WriteLine("For which day you want to sort the pictures ? (DD / MM / YYYY)"));
            console.Setup(func => func.ReadLine()).Returns("12/03/2222");


            UserInputService.get_user_entry(console.Object);

            console.VerifyAll();
        }

        [TestMethod]
        public void get_user_entry_name_test()
        {
            var console = new Mock<IConsole>();
            console.Setup(item => item.WriteLine("For which day you want to sort the pictures ? (DD / MM / YYYY)"));
            console.Setup(func => func.ReadLine()).Returns("12/03/2222");
            console.Setup(item => item.WriteLine("What did you do @ this day?"));

            UserInputService.get_user_entry(console.Object);

            console.VerifyAll();
        }

        [TestMethod]
        public void get_user_entry_description_test()
        {
            var console = new Mock<IConsole>();
            console.Setup(item => item.WriteLine("For which day you want to sort the pictures ? (DD / MM / YYYY)"));
            console.Setup(func => func.ReadLine()).Returns("12/03/2222");
            console.Setup(item => item.WriteLine("What did you do @ this day?"));
            console.Setup(item => item.WriteLine("Give a little description for this day."));

            UserInputService.get_user_entry(console.Object);

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

            DateTime parsedTime = new DateTime(2222, 03, 12);

            Assert.AreEqual(new DeviceUserEntry("test_name", "test_description", parsedTime), photoniced.device.services.UserInputService.get_user_entry(console.Object));

        }

        [TestMethod]
        public void get_user_entry_split_null_test()
        {
            var console = new Mock<IConsole>();

            Assert.ThrowsException<NullReferenceException>(() => photoniced.device.services.UserInputService.get_user_entry(console.Object));
        }
    }
}
