using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class Method_DTO
    {
        [DataMember]
        public string Name;
        [DataMember]
        public IEnumerable<Type_DTO> GenericArguments;
        [DataMember]
        public Tuple<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers;
        [DataMember]
        public Type_DTO ReturnType;
        [DataMember]
        public bool Extension;
        [DataMember]
        public IEnumerable<Parameter_DTO> Parameters;

    }
}