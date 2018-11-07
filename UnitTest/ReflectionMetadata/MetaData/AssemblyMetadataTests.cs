using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.ReflectionMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Logic.ReflectionMetadata.Tests
{
    [TestClass()]
    public class AssemblyMetadataTests
    {
        private Assembly testAssembly;

        [TestInitialize]
        public void Init()
        {
            string pathToDll = @"..\..\..\UnitTest\ExampleDLL.dll";
            testAssembly = Assembly.LoadFrom(pathToDll);
        }
        [TestMethod()]
        public void AssemblyMetadataTest()
        {
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(testAssembly);
            Assert.IsNotNull(assemblyMetadata);
        }

        [TestMethod()]
        public void GetInternalsTest()
        {
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(testAssembly);
            IEnumerable<IInternalGeter> internals = assemblyMetadata.GetInternals();

            Assert.IsNotNull(internals);
            string name = assemblyMetadata.m_Name;
            Assert.IsTrue(name.Contains("Example"));
        }
    }
}