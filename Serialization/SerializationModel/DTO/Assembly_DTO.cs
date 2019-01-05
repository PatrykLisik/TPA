using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class Assembly_DTO
    {
        [DataMember]
        public string Name;
        [DataMember]
        public IEnumerable<Namespace_DTO> Namespaces;
    }
}