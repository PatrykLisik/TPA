
using System.Collections.Generic;
using System.Linq;

namespace Logic.ReflectionMetadata
{
    public class ParameterMetadata :IInternalGeter
    {
        public string m_Name { get; private set; }
        public TypeMetadata m_TypeMetadata { get; private set; }

        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            this.m_Name = name;
            this.m_TypeMetadata = typeMetadata;
        }

        public IEnumerable<IInternalGeter> GetInternals()
        {
            return m_TypeMetadata.GetInternals();
        }
        public override string ToString()
        {
            return m_TypeMetadata.TypeName + " " + m_Name;
        }
    }
}