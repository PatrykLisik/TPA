using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using UnitTest.ReflectionMetadata.Metadata;

namespace ViewModel.TreeViewItems.Tests
{
    [TestClass()]
    public class TypeMetadataTreeViewItemTests
    {
        [TestMethod()]
        public void TypeMetadataTreeViewItemTest()
        {
            IEnumerable<TypeMetadataTreeViewItem> viewItems = from TypeMetadata _nm in TestAssemblyBuilder.GetTestTypetadata()
                                                              select new TypeMetadataTreeViewItem(_nm);
            List<string> ExpectedNames = new List<string> {"Enum ExampleEnum","Interface ExampleInterface",
                                                        "<Logic.ReflectionMetadata.TypeMetadata,Logic.ReflectionMetadata.TypeMetadata>Class GenericClass`2<Logic.ReflectionMetadata.TypeMetadata,Logic.ReflectionMetadata.TypeMetadata>",
                                                         "Class StaticExample","Class TestClass1" };
            List<int> ExpectedChildernCounts = new List<int> { 1, 1, 1, 1, 1 };

            IEnumerable<string> Names = from TypeMetadataTreeViewItem _nt in viewItems
                                        select _nt.Name;
            IEnumerable<int> ChilsernCounts = from TypeMetadataTreeViewItem _nt in viewItems
                                              select _nt.Children.Count;

            CollectionAssert.AreEquivalent(ExpectedChildernCounts, ChilsernCounts.ToList());
            CollectionAssert.AreEquivalent(ExpectedNames, Names.ToList());
        }

    }
}