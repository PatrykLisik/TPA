using System;
using System.Collections.Generic;

namespace Model.DTO
{
    public class TypeBaseDTO
    {

        public enum TypeKindBaseDTO
        {
            EnumType, StructType, InterfaceType, ClassType
        }

        public string TypeName;
        public string NamespaceName;
        public TypeBaseDTO BaseType;
        public IEnumerable<TypeBaseDTO> GenericArguments;
        public Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> Modifiers;
        public TypeKindBaseDTO TypeKind1;
        public IEnumerable<TypeBaseDTO> ImplementedInterfaces;
        public IEnumerable<TypeBaseDTO> NestedTypes;
        public IEnumerable<PropertyBaseDTO> Properties;
        public TypeBaseDTO DeclaringType;
        public IEnumerable<MethodBaseDTO> Methods;
        public IEnumerable<MethodBaseDTO> Constructors;
        public IEnumerable<ParameterBaseDTO> Fields;
    }
}