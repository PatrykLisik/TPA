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

        public string TypeName{ get; set; }
        public string NamespaceName{ get; set; }
        public TypeBaseDTO BaseType{ get; set; }
        public IEnumerable<TypeBaseDTO> GenericArguments{ get; set; }
        public Tuple<AccessLevelBaseDTO, SealedEnumBaseDTO, AbstractEnumBaseDTO> Modifiers{ get; set; }
        public TypeKindBaseDTO TypeKind1{ get; set; }
        public IEnumerable<TypeBaseDTO> ImplementedInterfaces{ get; set; }
        public IEnumerable<TypeBaseDTO> NestedTypes{ get; set; }
        public IEnumerable<PropertyBaseDTO> Properties{ get; set; }
        public TypeBaseDTO DeclaringType{ get; set; }
        public IEnumerable<MethodBaseDTO> Methods{ get; set; }
        public IEnumerable<MethodBaseDTO> Constructors{ get; set; }
        public IEnumerable<ParameterBaseDTO> Fields{ get; set; }
    }
}