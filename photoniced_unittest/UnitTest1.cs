using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.device;
using Moq;
using photoniced.essentials.commandline_parser.repos;

namespace photoniced_unittest
{
    [TestClass]
    public class DeviceTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Device(null));

            var comandline = new Mock<ICommandLineParserRepository>();
            var dev = new Device(comandline.Object);
            Assert.AreSame(dev.CmdParser, comandline.Object);
        }
    }
}
