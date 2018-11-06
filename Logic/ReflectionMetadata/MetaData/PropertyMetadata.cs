
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logic.ReflectionMetadata
{
    public class PropertyMetadata : IInternalGeter
    {
        public string m_Name { get; private set; }
        public TypeMetadata m_TypeMetadata { get; private set; }

        public static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
        {
            return from prop in props
                   where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
                   select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
        }

        public IEnumerable<IInternalGeter> GetInternals()
        {
            return m_TypeMetadata.GetInternals();

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