using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class ParameterMetadata
    {
        [DataMember]
        public string Name;
        [DataMember]
        public TypeMetadata_DTO TypeMetadata;
}