using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel.TreeViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.ReflectionMetadata.Metadata;

namespace ViewModel.TreeViewItems.Tests
{
    [TestClass()]
    public class AssemblyMetadataTreeViewItemTests
    {
        [TestMethod()]
        public void AssemblyMetadataTreeViewItemTest()
        {
            AssemblyMetadataTreeViewItem viewItem = new AssemblyMetadataTreeViewItem(TestAssemblyBuilder.GetTestAssemblyMetadata())
            {
                IsExpanded = true
            };
            string name = "ExampleDLL.dll";
            int childNumber = 1;
            Assert.IsTrue(viewItem.Name == name);
            Assert.IsTrue(viewItem.Children.Count == childNumber);
        }
    }
}