using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using UnitTest.ReflectionMetadata.Metadata;

namespace ViewModel.TreeViewItems.Tests
{
    [TestClass()]
    public class PropertyMetadaTreeViewItemTests
    {
        [TestMethod()]
        public void PropertyMetadaTreeViewItemTest()
        {
            IEnumerable<PropertyMetadaTreeViewItem> viewItems = from TypeMetadata _nm in TestAssemblyBuilder.GetTestTypetadata()
                                                                from PropertyMetadata _p in _nm.Properties
                                                                select new PropertyMetadaTreeViewItem(_p);
            List<string> ExpectedNames = new List<string> { "Property: Linq2SQL Linq2SQL",
                                                            "Property: ServiceB ServiceB",
                                                            "Property: ServiceC ServiceC",
                                                            "Property: ServiceA ServiceA",
                                                            "Property: Model Model",
                                                            "Property: String Property1",
                                                            "Property: String Property1",
                                                            "Property: T GenericProperty",
                                                            "Property: Int32 StaticProperty",
                                                            "Property: ClassB ClassB",
                                                            "Property: ClassA ClassA"
            };
            List<int> ExpectedChildernCounts = Enumerable.Repeat(1, 11).ToList();

            IEnumerable<string> Names = from PropertyMetadaTreeViewItem _pt in viewItems
                                        select _pt.Name;
            IEnumerable<int> ChilsernCounts = from PropertyMetadaTreeViewItem _pt in viewItems
                                              select _pt.Children.Count;

            CollectionAssert.AreEquivalent(ExpectedChildernCounts, ChilsernCounts.ToList());
            CollectionAssert.AreEquivalent(ExpectedNames, Names.ToList());
        }

    }
}