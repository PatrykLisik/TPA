using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModel.DTO
{
    [DataContract(IsReference = true)]
    public class TypeMetadata_DTO
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
        public TypeMetadata_DTO BaseType;
        [DataMember]
        public IEnumerable<TypeMetadata_DTO> GenericArguments;
        [DataMember]
        public Tuple<AccessLevel, SealedEnum, AbstractEnum> Modifiers;
        [DataMember]
        public TypeKind TypeKind1;
        [DataMember]
        public IEnumerable<TypeMetadata_DTO> ImplementedInterfaces;
        [DataMember]
        public IEnumerable<TypeMetadata_DTO> NestedTypes;
        [DataMember]
        public IEnumerable<PropertyMetadata> Properties;
        [DataMember]
        public TypeMetadata_DTO DeclaringType;
        [DataMember]
        public IEnumerable<MethodMetadata> Methods;
        [DataMember]
        public IEnumerable<MethodMetadata> Constructors;
        [DataMember]
        public IEnumerable<ParameterMetadata> Fields;
    }
}