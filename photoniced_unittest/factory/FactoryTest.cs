using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.factory;

namespace photoniced_unittest.factory
{
    [TestClass]
    class FactoryTest
    {
        [TestMethod]
        public void constructor_parser_test()
        {
            var factory = new Factory(null);

            Assert.IsNotNull(factory.CmdParser);
        }

        [TestMethod]
        public void constructor_device_test()
        {
            var factory = new Factory(null);

            Assert.IsNotNull(factory.Device);
        }

        [TestMethod]
        public void constructor_menu_test()
        {
            var factory = new Factory(null);

            Assert.IsNotNull(factory.Menu);
        }
    }
}
