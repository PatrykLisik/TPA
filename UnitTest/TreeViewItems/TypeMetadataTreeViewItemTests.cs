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
            List<string> ExpectedNames = new List<string> {"Private Class Model",
                                                            "Private Class ServiceA",
                                                            "Private Class ServiceB",
                                                            "Private Class ServiceC",
                                                            "Private Class ViewModel",
                                                            "Public Abstract Class AbstractClass",
                                                            "Public Class ClassWithAttribute",
                                                            "Public Class DerivedClass",
                                                            "Private Seald Enum Enum",
                                                            "Public Class GenericClass`1<Logic.ReflectionMetadata.TypeMetadata>",
                                                            "Public Abstract Interface IExample",
                                                            "Public Class ImplementationOfIExample",
                                                            "Private Class Linq2SQL",
                                                            "Public Class OuterClass",
                                                            "Public Seald Abstract Class StaticClass",
                                                            "Public Seald Struct Structure",
                                                            "Public Class ClassA",
                                                            "Public Class ClassB",
                                                            "Private Class View"
            };
            List<int> ExpectedChildernCounts = Enumerable.Repeat(1, 19).ToList();

            IEnumerable<string> Names = from TypeMetadataTreeViewItem _nt in viewItems
                                        select _nt.Name;
            IEnumerable<int> ChilsernCounts = from TypeMetadataTreeViewItem _nt in viewItems
                                              select _nt.Children.Count;

            CollectionAssert.AreEquivalent(ExpectedChildernCounts, ChilsernCounts.ToList());
            CollectionAssert.AreEquivalent(ExpectedNames, Names.ToList());
        }

    }
}