using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class Type_DTO
    {

        public enum TypeKind
        {
            EnumType, StructType, InterfaceType, ClassType
        }

        [DataMember]
        public string TypeName;
        [DataMember]
        public string NamespaceName;
        [DataMember]
        public Type_DTO BaseType;
        [DataMember]
        public IEnumerable<Type_DTO> GenericArguments;
        [DataMember]
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers;
        [DataMember]
        public TypeKind TypeKind1;
        [DataMember]
        public IEnumerable<Type_DTO> ImplementedInterfaces;
        [DataMember]
        public IEnumerable<Type_DTO> NestedTypes;
        [DataMember]
        public IEnumerable<Property_DTO> Properties;
        [DataMember]
        public Type_DTO DeclaringType;
        [DataMember]
        public IEnumerable<Method_DTO> Methods;
        [DataMember]
        public IEnumerable<Method_DTO> Constructors;
        [DataMember]
        public IEnumerable<Parameter_DTO> Fields;
    }
}