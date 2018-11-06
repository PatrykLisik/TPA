﻿
using Logic.ReflectionMetadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logic.ReflectionMetadata
{
    public class NamespaceMetadata : IInternalGeter
    {

        internal NamespaceMetadata(string name, IEnumerable<Type> types)
        {
            m_NamespaceName = name;
            m_Types = from type in types orderby type.Name select new TypeMetadata(type);
        }

        private readonly string m_NamespaceName;
        private IEnumerable<TypeMetadata> m_Types;
        public override string ToString()
        {
            return "Namesapce " + m_NamespaceName;
        }

        public IEnumerable<IInternalGeter> GetInternals()
        {
            return m_Types.ToList<IInternalGeter>();
        }
    }
}