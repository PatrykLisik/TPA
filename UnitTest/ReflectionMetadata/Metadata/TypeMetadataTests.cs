﻿using Logic.ReflectionMetadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.ReflectionMetadata.Metadata
{
    [TestClass()]
    public class TypeMetadataTests
    {
        IEnumerable<TypeMetadata> types;

        [TestInitialize]
        public void Init()
        {
            types = TestAssemblyBuilder.GetTestTypetadata();
        }

        [TestMethod()]
        public void NamesTest()
        {
            List<string> expectedNames = new List<string> {"Model",
"ServiceA",
"ServiceB",
"ServiceC",
"ViewModel",
"AbstractClass",
"ClassWithAttribute",
"DerivedClass",
"Enum",
"GenericClass`1",
"IExample",
"ImplementationOfIExample",
"Linq2SQL",
"OuterClass",
"StaticClass",
"Structure",
"ClassA",
"ClassB",
"View"
            };
            IEnumerable<string> TypeNames = from TypeMetadata _t in types
                                            select _t.TypeName;

            CollectionAssert.AreEquivalent(expectedNames, TypeNames.ToList());
        }

        [TestMethod()]
        public void ConstructorNamesTest()
        {
            List<string> expectedNames = new List<string> {"Model",
                                                            "ServiceA",
                                                            "ServiceB",
                                                            "ServiceC",
                                                            "ViewModel",
                                                            "AbstractClass",
                                                            "ClassWithAttribute",
                                                            "DerivedClass",
                                                            "Enum",
                                                            "GenericClass`1",
                                                            "IExample",
                                                            "ImplementationOfIExample",
                                                            "Linq2SQL",
                                                            "OuterClass",
                                                            "StaticClass",
                                                            "Structure",
                                                            "ClassA",
                                                            "ClassB",
                                                            "View"
            };
            IEnumerable<string> TypeNames = from TypeMetadata _t in types
                                            select _t.TypeName;

            CollectionAssert.AreEquivalent(expectedNames, TypeNames.ToList());
        }
    }
}