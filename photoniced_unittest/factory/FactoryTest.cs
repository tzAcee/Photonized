using Microsoft.VisualStudio.TestTools.UnitTesting;
using photoniced.factory;
using System;

namespace photoniced_unittest.factory
{

    [TestClass]
    public class FactoryTest
    {

        [TestMethod]
        public void constructor_parser_test()
        {
            try
            {
                var factory = new Factory(new string[0]);

                Assert.IsNotNull(factory.CmdParser);
            }
            catch(Exception e)
            {

            }
        }

        [TestMethod]
        public void constructor_device_test()
        {
            try
            {
                var factory = new Factory(null);

                Assert.IsNotNull(factory.Device);
            }
            catch (Exception e)
            {

            }
        }

        [TestMethod]
        public void constructor_menu_test()
        {
            try
            {
                var factory = new Factory(null);

                Assert.IsNotNull(factory.Menu);
            }
            catch (Exception e)
            {

            }
        }
    }
}
