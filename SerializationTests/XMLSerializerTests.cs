using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Tests
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
            XMLSerializer<TestClass> serializer = new XMLSerializer<TestClass>();
            XMLSerializer<TestClass> serializer2 = new XMLSerializer<TestClass>();
            TestClass testClass = new TestClass();
            string fileName = @"TestXML.xml";
            serializer.SaveToRepository(testClass, fileName);

            Assert.IsTrue(File.Exists(fileName));

            string resultXML = File.ReadAllText(fileName);

            TestClass testClasssLoaded = serializer2.LoadFromRepository(fileName);
            Assert.IsTrue(testClass.Field1 == testClasssLoaded.Field1);
            Assert.IsTrue(testClass.Field2 == testClasssLoaded.Field2);




        }

    }
}