using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using photoniced.common;

namespace photoniced_unittest.common
{
    [TestClass]
    public class RequiredTest
    {
        [TestMethod]
        public void exception_test()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Required.NotNull<string>(null, "name"));
        }

        [TestMethod]
        public void success_test()
        {
            var reader = new Mock<IList>();
            var output = Required.NotNull(reader.Object, nameof(reader.Object));
            
            Assert.IsNotNull(output);
        }
        
        [TestMethod]
        public void type_test()
        {
            var reader = new Mock<IList>();
            var output = Required.NotNull(reader.Object, nameof(reader.Object));
            
            Assert.AreSame(output, reader.Object);
        }
    }
}