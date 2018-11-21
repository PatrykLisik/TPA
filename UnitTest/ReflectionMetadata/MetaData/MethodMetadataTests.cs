using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Logic.ReflectionMetadata.Tests
{
    [TestClass()]
    public class MethodMetadataTests
    {
        IEnumerable<MethodMetadata> methods;

        [TestInitialize]
        public void Init()
        {
            object oo = new object();
            methods = new TypeMetadata(oo.GetType()).Methods;

        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.IsTrue(true);
        }
    }
}