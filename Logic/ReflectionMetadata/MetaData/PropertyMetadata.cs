
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Logic.ReflectionMetadata
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(TypeMetadata))]
    public class PropertyMetadata
    {
        [DataMember]
        public string m_Name { get; private set; }
        [DataMember]
        public TypeMetadata m_TypeMetadata { get; private set; }

        public static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
        {
            return from prop in props
                   where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
                   select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
        }


        public override string ToString()
        {
            return "Property: " + m_TypeMetadata.TypeName + " "+m_Name;
        }

        private PropertyMetadata(string propertyName, TypeMetadata propertyType)
        {
            m_Name = propertyName;
            m_TypeMetadata = propertyType;
        }

    }
}