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
            List<string> expectedNames = new List<string> {
                "Equals","GetHashCode","ToString","ToString","CompareTo","ToString","ToString","HasFlag","GetTypeCode","GetType","SomeMethod",
                "get_GenericType2","set_GenericType2","NestedGenericMethod","ToString","Equals","GetHashCode","GetType","DoNothing","ToString",
                "Equals","GetHashCode","GetType","get_Int_2","set_Int_2","Add","ToString","Equals","GetHashCode","GetType"};
            IEnumerable<string> TypeNames = from MethodMetadata _method in methods
                                                  select _method.Name;

            CollectionAssert.AreEquivalent(expectedNames, TypeNames.ToList());
        }

        [TestMethod()]
        public void ReturnTypeNamesTest()
        {
            List<string> expectedNames = new List<string> {
                "Boolean","Int32","String","String","Int32","String","String","Boolean","TypeCode","Type","Int32","T2","Void","IEnumerable`1",
                "String","Boolean","Int32","Type","Void","String","Boolean","Int32","Type","Int32","Void","Void","String","Boolean","Int32","Type"};
            IEnumerable<string> ReturnTypeNames = from MethodMetadata _method in methods
                                                  select _method.ReturnType.TypeName;

            CollectionAssert.AreEquivalent(expectedNames, ReturnTypeNames.ToList());
        }


    }
}