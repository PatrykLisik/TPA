using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
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
            string pathToDll = @"..\..\..\UnitTest\ExampleDLL.dll";
            AssemblyMetadata testAssembly = new AssemblyMetadata(Assembly.LoadFrom(pathToDll));
            //IEnumerable<IInternalGeter> namespaces = testAssembly.GetInternals();
            //var ListOfListOfTypes = from IInternalGeter _types in namespaces
             //                       select _types.GetInternals();
            //types = ListOfListOfTypes.SelectMany(x => x);


        }
    }
}