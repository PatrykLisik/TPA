using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.ReflectionMetadata.Metadata
{
    [TestClass()]
    public class AssemblyMetadataTests
    {
        private AssemblyMetadata testAssembly;

        [TestInitialize]
        public void Init()
        {
            testAssembly = TestAssemblyBuilder.GetTestAssemblyMetadata();
        }
        [TestMethod()]
        public void AssemblyMetadataTest()
        {
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(TestAssemblyBuilder.GetTestAssembly());
            Assert.IsNotNull(assemblyMetadata);
        }

        [TestMethod()]
        public void NameTest()
        {
            const string expectedAssemblyName = "TPA.ApplicationArchitecture.dll";
            Assert.IsTrue(expectedAssemblyName == testAssembly.Name);
        }

    }
}