using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class Property_DTO
    {
        [DataMember]
        public string Name;
        [DataMember]
        public Type_DTO TypeMetadata;
    }
}