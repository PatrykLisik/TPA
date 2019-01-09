using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel.TreeViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.ReflectionMetadata.Metadata;
using Logic.ReflectionMetadata;

namespace ViewModel.TreeViewItems.Tests
{
    [TestClass()]
    public class NamesapceTreeViewItemTests
    {
        [TestMethod()]
        public void NamesapceTreeViewItemTest()
        {
            IEnumerable<NamesapceTreeViewItem> viewItems = from NamespaceMetadata _nm in TestAssemblyBuilder.GetTestNamespaces()
                                                           select new NamesapceTreeViewItem(_nm);
            List<string> ExpectedNames = new List<string> {
                "Namesapce TPA.ApplicationArchitecture.BusinessLogic",
                "Namesapce TPA.ApplicationArchitecture.Data",
                "Namesapce TPA.ApplicationArchitecture.Presentation"
            };
            List<int> ExpectedChildernCounts = new List<int> { 1,1,1 };

            IEnumerable<string> Names = from NamesapceTreeViewItem _nt in viewItems
                                        select _nt.Name;
            IEnumerable<int> ChilsernCounts = from NamesapceTreeViewItem _nt in viewItems
                                              select _nt.Children.Count;

            CollectionAssert.AreEquivalent(ExpectedChildernCounts, ChilsernCounts.ToList());
            CollectionAssert.AreEquivalent(ExpectedNames, Names.ToList());

        }
    }
}