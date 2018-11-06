
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Logic.ReflectionMetadata
{
    internal class PropertyMetadata : IInternalGeter
    {

        internal static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
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
            return m_TypeMetadata.ToString();
        }
        #region private
        private readonly string m_Name;
        private TypeMetadata m_TypeMetadata;
        private PropertyMetadata(string propertyName, TypeMetadata propertyType)
        {
            m_Name = propertyName;
            m_TypeMetadata = propertyType;
        }
        #endregion

    }
}