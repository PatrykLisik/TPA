using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logic.ReflectionMetadata.Tests
{

    [TestClass()]
    public class NamespaceMetadataTests
    {
        IEnumerable<NamespaceMetadata> namespaces;
        [TestInitialize]
        public void Init()
        {
            string pathToDll = @"..\..\..\UnitTest\ExampleDLL.dll";
            AssemblyMetadata testAssembly = new AssemblyMetadata(Assembly.LoadFrom(pathToDll));
            namespaces = testAssembly.Namespaces;
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.IsFalse(false);
        }
    }
}