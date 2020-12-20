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
    public class MenuTest
    {
        [TestMethod]
        public void constructor_exception_test()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Menu(null));
        }
        
        
    }
}