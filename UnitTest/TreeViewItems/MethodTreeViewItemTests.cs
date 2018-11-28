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
            List<string> ExpectedNames = new List<string> {"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual Int32 GetHashCode()",
                                                            "Public Virtual String ToString()",
                                                            "Public Virtual String ToString(Logic.ReflectionMetadata.ParameterMetadata ,Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual Int32 CompareTo(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public String ToString(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual String ToString(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Boolean HasFlag(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual TypeCode GetTypeCode()",
                                                            "Public Type GetType()",
                                                            "Public Abstract Virtual Int32 SomeMethod()",
                                                            "Public T2 get_GenericType2()",
                                                            "Public Void set_GenericType2(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public IEnumerable`1 NestedGenericMethod<Logic.ReflectionMetadata.TypeMetadata ,Logic.ReflectionMetadata.TypeMetadata>(Logic.ReflectionMetadata.ParameterMetadata ,Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual String ToString()",
                                                            "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual Int32 GetHashCode()",
                                                            "Public Type GetType()",
                                                            "Public Static Void DoNothing()",
                                                            "Public Virtual String ToString()",
                                                            "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual Int32 GetHashCode()",
                                                            "Public Type GetType()",
                                                            "Public Int32 get_Int_2()",
                                                            "Public Void set_Int_2(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Void Add<Logic.ReflectionMetadata.TypeMetadata>(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual String ToString()",
                                                            "Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
                                                            "Public Virtual Int32 GetHashCode()",
                                                            "Public Type GetType()"};
            List<int> ExpectedChildernCounts = Enumerable.Repeat(1, 30).ToList();

            IEnumerable<string> Names = from MethodTreeViewItem _pt in viewItems
                                        select _pt.Name;
            IEnumerable<int> ChilsernCounts = from MethodTreeViewItem _pt in viewItems
                                              select _pt.Children.Count;

            CollectionAssert.AreEquivalent(ExpectedChildernCounts, ChilsernCounts.ToList());
            CollectionAssert.AreEquivalent(ExpectedNames, Names.ToList());
        }
    }
}
