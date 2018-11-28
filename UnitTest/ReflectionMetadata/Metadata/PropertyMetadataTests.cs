using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.ReflectionMetadata.Metadata
{
    [TestClass()]
    public class PropertyMetadataTests
    {
        IEnumerable<PropertyMetadata> properties;
        [TestInitialize]
        public void Init()
        {
            properties = from TypeMetadata _t in TestAssemblyBuilder.GetTestTypetadata()
                         from PropertyMetadata _p in _t.Properties
                         select _p;

        }

        [TestMethod()]
        public void NamesTest()
        {
            List<string> expectedNames = new List<string> {"T2","Int32"};
            IEnumerable<string> PropertyNames = from PropertyMetadata _p in properties
                                                select _p.TypeMetadata.TypeName;

            CollectionAssert.AreEquivalent(expectedNames, PropertyNames.ToList());
        }
    }
}