using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Logic.ReflectionMetadata
{
    [DataContract(IsReference = true)]
    public class PropertyMetadata
    {
        [DataMember]
        private string m_Name;
        [DataMember]
        private TypeMetadata m_TypeMetadata;

        public string Name { get => m_Name; set => m_Name = value; }
        public TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }

        public static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
        {
            return from prop in props
                   where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
                   select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
        }




        private PropertyMetadata(string propertyName, TypeMetadata propertyType)
        {
            Name = propertyName;
            TypeMetadata = propertyType;
        }

    }
}