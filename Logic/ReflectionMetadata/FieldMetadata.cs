using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReflectionMetadata
{
    internal class FieldMetadata : IInternalGeter
    {
        String m_FieldName;
        TypeMetadata m_Type;

        public FieldMetadata(string m_FieldName, TypeMetadata m_Type)
        {
            this.m_FieldName = m_FieldName ?? throw new ArgumentNullException(nameof(m_FieldName));
            this.m_Type = m_Type ?? throw new ArgumentNullException(nameof(m_Type));
        }

        public IEnumerable<IInternalGeter> GetInternals()
        {
            return m_Type.GetInternals();
        }

        public override string ToString()
        {
            return m_Type.TypeName + " " + m_FieldName;
        }
    }
}
