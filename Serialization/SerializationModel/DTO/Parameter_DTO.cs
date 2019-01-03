using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class Parameter_DTO
    {
        [DataMember]
        public string Name;
        [DataMember]
        public Type_DTO TypeMetadata;
    }
}