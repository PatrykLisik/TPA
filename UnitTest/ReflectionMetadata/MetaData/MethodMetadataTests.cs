using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.ReflectionMetadata.Tests
{
    [TestClass()]
    public class MethodMetadataTests
    {
        IEnumerable<MethodMetadata> methods;

        [TestInitialize]
        public void Init()
        {
            object oo = new object();
            methods = new TypeMetadata(oo.GetType()).m_Methods;

        }

        [TestMethod()]
        public void GetInternalsTest()
        {
            foreach (MethodMetadata methodMetadata in methods)
            {
                Assert.IsFalse(methodMetadata.GetInternals().Any());
            }
        }

        [TestMethod()]
        public void ToStringTest()
        {
            HashSet<string> expectedNameList = new HashSet<string>() {
                "Public Type GetType()",
                "Public Virtual Int32 GetHashCode()",
                "Public Virtual String ToString()",
                "Public Virtual Boolean Equals(Object obj)",
                "Public Static Boolean Equals(Object objA ,Object objB)",
                "Public Static Boolean ReferenceEquals(Object objA ,Object objB)",
            };
            foreach (MethodMetadata _method in methods)
            {
                Assert.IsTrue(expectedNameList.Contains(_method.ToString()));
            }
        }
    }
}