using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization;

namespace Logic.Serialization.Tests
{
    [TestClass()]
    public class XMLSerializerTests
    {
        [DataContract(IsReference = true)]
        internal class TestClass
        {
            [DataMember]
            private int field1 = 42;
            [DataMember]
            private string field2 = "tpa2018";

            public int Field1 { get => field1; set => field1 = value; }
            public string Field2 { get => field2; set => field2 = value; }
        }


        [TestMethod()]
        public void SerliaizeTest()
        {
            string expectedXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<XMLSerializerTests.TestClass xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" z:Id=\"1\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\" xmlns=\"http://schemas.datacontract.org/2004/07/Logic.Serialization.Tests\">\r\n  <field1>42</field1>\r\n  <field2 z:Id=\"2\">tp2018</field2>\r\n</XMLSerializerTests.TestClass>";
            XMLSerializer<TestClass> serializer = new XMLSerializer<TestClass>();
            XMLSerializer<TestClass> serializer2 = new XMLSerializer<TestClass>();
            TestClass testClass = new TestClass();
            string fileName = @"TestXML.xml";
            serializer.SaveToRepository(testClass, fileName);

            Assert.IsTrue(File.Exists(fileName));

            string resultXML = File.ReadAllText(fileName);
            Assert.IsTrue(resultXML == expectedXML);

            TestClass testClasssLoaded = serializer2.LoadFromRepository(fileName);
            Assert.IsTrue(testClass.Field1 == testClasssLoaded.Field1);
            Assert.IsTrue(testClass.Field2 == testClasssLoaded.Field2);




        }

    }


}
