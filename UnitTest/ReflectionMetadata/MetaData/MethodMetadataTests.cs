using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.ReflectionMetadata.Metadata
{
    [TestClass()]
    public class MethodMetadataTests
    {
        IEnumerable<MethodMetadata> methods;

        [TestInitialize]
        public void Init()
        {
            methods = TestAssemblyBuilder.GetMethodmetadatas();


        }

        [TestMethod()]
        public void NamesTest()
        {
            Assert.IsNotNull(methods);
            List<string> expectedNames = new List<string> {     "get_Linq2SQL",
                                                                "set_Linq2SQL",
                                                                "ToString",
                                                                "Equals",
                                                                "GetHashCode",
                                                                "GetType",
                                                                "get_ServiceB",
                                                                "set_ServiceB",
                                                                "ToString",
                                                                "Equals",
                                                                "GetHashCode",
                                                                "GetType",
                                                                "get_ServiceC",
                                                                "set_ServiceC",
                                                                "ToString",
                                                                "Equals",
                                                                "GetHashCode",
                                                                "GetType",
                                                                "get_ServiceA",
                                                                "set_ServiceA",
                                                                "ToString",
                                                                "Equals",
                                                                "GetHashCode",
                                                                "GetType",
                                                                "get_Model",
                                                                "set_Model",
                                                                "ToString",
                                                                "Equals",
                                                                "GetHashCode",
                                                                "GetType",
                                                                "Connect",
                                                                "ToString",
                                                                "Equals",
                                                                "GetHashCode",
                                                                "GetType",
                                                                "ToString",
                                                                "Equals",
                                                                "GetHashCode",
                                                                "GetType"
            };
            IEnumerable<string> TypeNames = from MethodMetadata _method in methods
                                            select _method.Name;

            CollectionAssert.AreEquivalent(expectedNames, TypeNames.ToList());
        }

        [TestMethod()]
        public void ReturnTypeNamesTest()
        {
            List<string> expectedNames = new List<string> {"Linq2SQL",
                                                            "Void",
                                                            "String",
                                                            "Boolean",
                                                            "Int32",
                                                            "Type",
                                                            "ServiceB",
                                                            "Void",
                                                            "String",
                                                            "Boolean",
                                                            "Int32",
                                                            "Type",
                                                            "ServiceC",
                                                            "Void",
                                                            "String",
                                                            "Boolean",
                                                            "Int32",
                                                            "Type",
                                                            "ServiceA",
                                                            "Void",
                                                            "String",
                                                            "Boolean",
                                                            "Int32",
                                                            "Type",
                                                            "Model",
                                                            "Void",
                                                            "String",
                                                            "Boolean",
                                                            "Int32",
                                                            "Type",
                                                            "Void",
                                                            "String",
                                                            "Boolean",
                                                            "Int32",
                                                            "Type",
                                                            "String",
                                                            "Boolean",
                                                            "Int32",
                                                            "Type"
            };
            IEnumerable<string> ReturnTypeNames = from MethodMetadata _method in methods
                                                  select _method.ReturnType.TypeName;

            CollectionAssert.AreEquivalent(expectedNames, ReturnTypeNames.ToList());
        }


    }
}