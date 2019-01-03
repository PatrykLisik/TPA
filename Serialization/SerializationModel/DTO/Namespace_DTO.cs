using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class NamespaceMetadata
    {
        [DataMember]
        public string NamespaceName;
        [DataMember]
        public IEnumerable<TypeMetadata_DTO> Types;
    }
}