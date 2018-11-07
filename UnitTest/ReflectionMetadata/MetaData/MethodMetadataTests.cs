using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logic.ReflectionMetadata.Tests
{
    [TestClass()]
    public class MethodMetadataTests
    {
        [TestInitialize]
        public void Init()
        {
            string pathToDll = @"..\..\..\UnitTest\ExampleDLL.dll";
            AssemblyMetadata testAssembly = new AssemblyMetadata(Assembly.LoadFrom(pathToDll));
            IEnumerable<IInternalGeter> namespaces = testAssembly.GetInternals();
            var ListOfListOfTypes = from IInternalGeter _types in namespaces
                                    select _types.GetInternals();
            IEnumerable<IInternalGeter> types = ListOfListOfTypes.SelectMany(x => x);


        }

        [TestMethod()]
        public void GetInternalsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}