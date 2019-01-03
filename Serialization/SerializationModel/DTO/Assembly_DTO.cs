using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class Assembly_DTO
    {
        [DataMember]
        public string m_Name;
        [DataMember]
        public IEnumerable<Namespace_DTO> m_Namespaces;
    }
}