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
"Public String get_Property1()",
"Public Void set_Property1(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Abstract Virtual Void AbstractMethod()",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()",
"Public Virtual Void AbstractMethod()",
"Public String get_Property1()",
"Public Void set_Property1(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Virtual String ToString()",
"Public Virtual String ToString(Logic.ReflectionMetadata.ParameterMetadata ,Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 CompareTo(Logic.ReflectionMetadata.ParameterMetadata)",
"Public String ToString(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual String ToString(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Boolean HasFlag(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual TypeCode GetTypeCode()",
"Public Type GetType()",
"Public T get_GenericProperty()",
"Public Void set_GenericProperty(Logic.ReflectionMetadata.ParameterMetadata)",
"Public T GenericMethod(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()",
"Public Abstract Virtual Void MethodA()",
"Public Abstract Virtual Single MethodB()",
"Public Virtual Void MethodA()",
"Public Virtual Single MethodB()",
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
"Public Type GetType()",
"Public Static Int32 get_StaticProperty()",
"Public Static Void set_StaticProperty(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Static Void StaticMethod1()",
"Public Static Single StaticMethod2()",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Virtual String ToString()",
"Public Type GetType()",
"Public ClassB get_ClassB()",
"Public Void set_ClassB(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()",
"Public ClassA get_ClassA()",
"Public Void set_ClassA(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()",
"Public Virtual String ToString()",
"Public Virtual Boolean Equals(Logic.ReflectionMetadata.ParameterMetadata)",
"Public Virtual Int32 GetHashCode()",
"Public Type GetType()"
            };
            List<int> ExpectedChildernCounts = Enumerable.Repeat(1, 110).ToList();

            IEnumerable<string> Names = from MethodTreeViewItem _pt in viewItems
                                        select _pt.Name;
            IEnumerable<int> ChilsernCounts = from MethodTreeViewItem _pt in viewItems
                                              select _pt.Children.Count;

            CollectionAssert.AreEquivalent(ExpectedChildernCounts, ChilsernCounts.ToList());
            CollectionAssert.AreEquivalent(ExpectedNames, Names.ToList());
        }
    }
}
