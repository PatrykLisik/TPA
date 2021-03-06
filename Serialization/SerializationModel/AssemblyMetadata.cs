
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SerializationModel
{
  public class AssemblyMetadata : IInternalGeter
    {

    public AssemblyMetadata(Assembly assembly)
    {
      m_Name = assembly.ManifestModule.Name;
      m_Namespaces = from Type _type in assembly.GetTypes()
                     where _type.GetVisible()
                     group _type by _type.GetNamespace() into _group
                     orderby _group.Key
                     select new NamespaceMetadata(_group.Key, _group);
    }

    public string m_Name;
    private IEnumerable<NamespaceMetadata> m_Namespaces;


        public IEnumerable<IInternalGeter> GetInternals()
        {
            return m_Namespaces.ToList<IInternalGeter>();
        }
    }
}