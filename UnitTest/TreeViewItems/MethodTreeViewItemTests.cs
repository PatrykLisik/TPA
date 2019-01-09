using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using UnitTest.ReflectionMetadata.Metadata;

namespace ViewModel.TreeViewItems.Tests
{
    [TestClass()]
    public class MethodTreeViewItemTests
    {
        [TestMethod()]
        public void MethodTreeViewItemTest()
        {
            IEnumerable<MethodTreeViewItem> viewItems = from TypeMetadata _nm in TestAssemblyBuilder.GetTestTypetadata()
                                                        from MethodMetadata _p in _nm.Methods
                                                        select new MethodTreeViewItem(_p);
            List<string> ExpectedNames = new List<string> {
                                "Public Linq2SQL get_Linq2SQL()",
                                "Public Void set_Linq2SQL(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual String ToString()",
                                "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual Int32 GetHashCode()",
                                "Public Type GetType()",
                                "Public ServiceB get_ServiceB()",
                                "Public Void set_ServiceB(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual String ToString()",
                                "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual Int32 GetHashCode()",
                                "Public Type GetType()",
                                "Public ServiceC get_ServiceC()",
                                "Public Void set_ServiceC(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual String ToString()",
                                "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual Int32 GetHashCode()",
                                "Public Type GetType()",
                                "Public ServiceA get_ServiceA()",
                                "Public Void set_ServiceA(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual String ToString()",
                                "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual Int32 GetHashCode()",
                                "Public Type GetType()",
                                "Public Model get_Model()",
                                "Public Void set_Model(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual String ToString()",
                                "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual Int32 GetHashCode()",
                                "Public Type GetType()",
                                "Public Void Connect()",
                                "Public Virtual String ToString()",
                                "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual Int32 GetHashCode()",
                                "Public Type GetType()",
                                "Public Virtual String ToString()",
                                "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                "Public Virtual Int32 GetHashCode()",
                                "Public Type GetType()"
            };
            List<int> ExpectedChildernCounts = Enumerable.Repeat(1, 39).ToList();

            IEnumerable<string> Names = from MethodTreeViewItem _pt in viewItems
                                        select _pt.Name;
            IEnumerable<int> ChilsernCounts = from MethodTreeViewItem _pt in viewItems
                                              select _pt.Children.Count;

            CollectionAssert.AreEquivalent(ExpectedChildernCounts, ChilsernCounts.ToList());
            CollectionAssert.AreEquivalent(ExpectedNames, Names.ToList());
        }
    }
}
