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
    public class TypeMetadataTests
    {
        IEnumerable<IInternalGeter> types;
        [TestInitialize]
        public void Init()
        {
            string pathToDll = @"..\..\..\UnitTest\bin\Debug\ExampleDLL.dll";
            AssemblyMetadata testAssembly = new AssemblyMetadata(Assembly.LoadFrom(pathToDll));
            IEnumerable<IInternalGeter>  namespaces = testAssembly.GetInternals();
            var ListOfListOfTypes = from IInternalGeter _types in namespaces
                                    select _types.GetInternals();
            types = ListOfListOfTypes.SelectMany(x => x);


        }

        [TestMethod()]
        public void TypeMetadataTest()
        {
            Assert.IsTrue(types.Any());

           
        }

        [TestMethod()]
        public void GetInternalsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            HashSet<string> expectedNameList = new HashSet<string>() { "ExampleEnum", "ExampleInterface", "GenericClass`2", "StaticExample", "TestClass1" };
            foreach (IInternalGeter _type in types)
            {
                if (expectedNameList.Contains(_type.ToString())){
                    Assert.IsTrue(false);
                }
            }
        }
    }
}