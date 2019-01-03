using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class PropertyMetadata
    {
        [DataMember]
        public string Name;
        [DataMember]
        public TypeMetadata_DTO TypeMetadata;
    }
}