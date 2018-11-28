using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.ReflectionMetadata.Metadata
{

    [TestClass()]
    public class NamespaceMetadataTests
    {
        IEnumerable<NamespaceMetadata> namespaces;
        [TestInitialize]
        public void Init()
        {
            namespaces = TestAssemblyBuilder.GetTestNamespaces();
        }

        [TestMethod()]
        public void NamesTest()
        {
            IEnumerable<string> expectedNames = new List<string> { "Example" };
            IEnumerable<string> namespacesNames = from NamespaceMetadata _namespace in namespaces
                                                  select _namespace.NamespaceName;

            CollectionAssert.AreEquivalent(expectedNames.ToList(), namespacesNames.ToList());
        }

        [TestMethod()]
        public void TypeTest()
        {
            List<string> expectedTypesNames = new List<string>{"ExampleEnum","ExampleInterface","GenericClass`2","StaticExample","TestClass1" };
            IEnumerable<string> namespaceTypesNames = from NamespaceMetadata _namespace in namespaces
                                                      from TypeMetadata type in _namespace.Types
                                                      select type.TypeName;

            CollectionAssert.AreEquivalent(expectedTypesNames, namespaceTypesNames.ToList());
        }

    }
}