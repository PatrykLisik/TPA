using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DTO;
using Moq;
using static Model.DTO.TypeDataBaseDTO;

namespace DataBaseRepositoryTest
{
    [TestClass]
    public class DataBaseTest
    {
        Mock<MainContext> mockContext;
        DBService service;

        /*MOCK*/
        List<NamespaceDataBaseDTO> namespaces;
        List<TypeDataBaseDTO> types;

        [TestInitialize]
        public void Init()
        {
            /* INIT DO TESTOWANIA Z BAZA
            Assembly currentAssem = Assembly.LoadFrom(@"..\..\..\..\TPA_repo\UnitTest\ExampleDLL.dll");
            assemblyMeta = new AssemblyMetadata(currentAssem);

            MainContext db = new MainContext();

            Model.DTO.AssemblyDataBaseDTO assemblyModel = assemblyMeta.ToBaseDTO().MapToDatabaseModel(); //ZLE
            db.assemblies.Add(assemblyModel);
            db.SaveChanges();
            */

            /*INIT DO TESTOWANIA BEZ BAZY - MOQ*/
            types = new List<TypeDataBaseDTO>
            {
                new TypeDataBaseDTO{ TypeName = "ServiceA", TypeKind1 = TypeKindDataBaseDTO.ClassType},
                new TypeDataBaseDTO{ TypeName = "ServiceB", TypeKind1 = TypeKindDataBaseDTO.ClassType},
                new TypeDataBaseDTO{ TypeName = "ServiceC", TypeKind1 = TypeKindDataBaseDTO.ClassType}
            };

            namespaces = new List<NamespaceDataBaseDTO>
            {
                new NamespaceDataBaseDTO{ NamespaceName = "TPA.ApplicationArchitecture.BusinessLogic", Types = types},
                new NamespaceDataBaseDTO{ NamespaceName = "TPA.ApplicationArchitecture.Data"},
                new NamespaceDataBaseDTO{ NamespaceName = "TPA.ApplicationArchitecture.Presentation"}
            };

            var data = new List<AssemblyDataBaseDTO>
            {
                new AssemblyDataBaseDTO { Name = "ExampleDLL.dll", Namespaces = namespaces }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<AssemblyDataBaseDTO>>();
            mockSet.As<IQueryable<AssemblyDataBaseDTO>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AssemblyDataBaseDTO>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AssemblyDataBaseDTO>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AssemblyDataBaseDTO>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext = new Mock<MainContext>();
            mockContext.Setup(c => c.assemblies).Returns(mockSet.Object);

            service = new DBService(mockContext.Object);

        }

        [TestMethod]
        public void AssemblyNameTests()
        {
            List<AssemblyDataBaseDTO> assemblyDataBaseDTOs = service.GetAllAssemblies();

            Assert.AreEqual(1, assemblyDataBaseDTOs.Count);
            Assert.AreEqual("ExampleDLL.dll", assemblyDataBaseDTOs[0].Name);
        }

        [TestMethod]
        public void NamespacesTests()
        {
            List<AssemblyDataBaseDTO> assemblyDataBaseDTOs = service.GetAllAssemblies();

            Assert.AreEqual(3, assemblyDataBaseDTOs[0].Namespaces.Count);
            CollectionAssert.AreEquivalent(assemblyDataBaseDTOs[0].Namespaces.ToList(), namespaces);
        }

        [TestMethod]
        public void TypesTests()
        {
            List<AssemblyDataBaseDTO> assemblyDataBaseDTOs = service.GetAllAssemblies();

            Assert.AreEqual(3, assemblyDataBaseDTOs[0].Namespaces.ToList()[0].Types.Count);
            CollectionAssert.AreEquivalent(assemblyDataBaseDTOs[0].Namespaces.ToList()[0].Types.ToList(), types);
        }
    }
}
