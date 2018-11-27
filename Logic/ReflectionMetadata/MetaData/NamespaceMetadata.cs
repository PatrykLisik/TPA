
using Logic.ReflectionMetadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Logic.ReflectionMetadata
{
    [DataContract(IsReference = true)]
    public class NamespaceMetadata
    {
        [DataMember]
        private string m_NamespaceName;
        [DataMember]
        private IEnumerable<TypeMetadata> m_Types;

        public string NamespaceName { get => m_NamespaceName; set => m_NamespaceName = value; }
        public IEnumerable<TypeMetadata> Types { get => m_Types; set => m_Types = value; }

        internal NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            NamespaceName = name;
            Types = from type in types orderby type.Name select new TypeMetadata(type);
        }

    }
}