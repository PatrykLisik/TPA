using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class Namespace_DTO
    {
        [DataMember]
        public string NamespaceName;
        [DataMember]
        public IEnumerable<Type_DTO> Types;
    }
}