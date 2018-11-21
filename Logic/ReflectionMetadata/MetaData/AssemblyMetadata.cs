
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logic.ReflectionMetadata
{
    public class AssemblyMetadata
    {
        private readonly string m_Name;
        private readonly IEnumerable<NamespaceMetadata> m_Namespaces;

        public AssemblyMetadata(Assembly assembly)
        {
            m_Name = assembly.ManifestModule.Name;
            m_Namespaces = from Type _type in assembly.GetTypes()
                           where _type.GetVisible()
                           group _type by _type.GetNamespace() into _group
                           orderby _group.Key
                           select new NamespaceMetadata(_group.Key, _group);
        }

        public IEnumerable<NamespaceMetadata> Namespaces => m_Namespaces;

        public string Name => m_Name;
    }
}