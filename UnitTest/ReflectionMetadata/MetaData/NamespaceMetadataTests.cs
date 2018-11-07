using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.ReflectionMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Logic.ReflectionMetadata.Tests
{

    [TestClass()]
    public class NamespaceMetadataTests
    {
        IEnumerable<IInternalGeter> namespaces;
        [TestInitialize]
        public void Init()
        {
            string pathToDll = @"..\..\..\UnitTest\bin\Debug\ExampleDLL.dll";
            AssemblyMetadata testAssembly = new AssemblyMetadata(Assembly.LoadFrom(pathToDll));
            namespaces = testAssembly.GetInternals();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.IsNotNull(namespaces);
            string namesapcename = namespaces.ToArray().Last().ToString();
            Assert.IsTrue(namesapcename.Contains("Namesapce Example"));
        }

        [TestMethod()]
        public void GetInternalsTest()
        {
            IEnumerable<IInternalGeter> internals = namespaces.First().GetInternals();
            Assert.IsTrue(internals.Any());
        }
    }
}