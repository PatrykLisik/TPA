using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class MethodMetadata
    {
        [DataMember]
        public string Name;
        [DataMember]
        public IEnumerable<TypeMetadata_DTO> GenericArguments;
        [DataMember]
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers;
        [DataMember]
        public TypeMetadata_DTO ReturnType;
        [DataMember]
        public bool Extension;
        [DataMember]
        public IEnumerable<ParameterMetadata> Parameters;

    }
}