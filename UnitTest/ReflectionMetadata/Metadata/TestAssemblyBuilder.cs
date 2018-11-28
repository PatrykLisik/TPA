using Logic.ReflectionMetadata;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTest.ReflectionMetadata.Metadata
{
    internal static class TestAssemblyBuilder
    {
        static readonly string pathToDll = @"..\..\..\UnitTest\ExampleDLL.dll";
        public static Assembly GetTestAssembly()
        {

            return Assembly.LoadFrom(pathToDll);
        }

        public static AssemblyMetadata GetTestAssemblyMetadata()
        {
            return new AssemblyMetadata(GetTestAssembly());
        }

        public static IEnumerable<NamespaceMetadata> GetTestNamespaces()
        {
            return GetTestAssemblyMetadata().Namespaces;
        }

        public static IEnumerable<TypeMetadata> GetTestTypetadata()
        {
            return from NamespaceMetadata _ns in GetTestNamespaces()
                   from TypeMetadata _type in _ns.Types
                   select _type;
        }

        public static IEnumerable<MethodMetadata> GetMethodmetadatas()
        {
            return from TypeMetadata _t in GetTestTypetadata()
                   from MethodMetadata _m in _t.Methods
                   select _m;

        }
    }
}
