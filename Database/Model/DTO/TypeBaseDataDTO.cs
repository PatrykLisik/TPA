using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class TypeDataBaseDTO
    {

        public enum TypeKindDataBaseDTO
        {
            EnumType, StructType, InterfaceType, ClassType
        }
        [Key]
        public string TypeName{ get; set; }
        public string NamespaceName{ get; set; }
        public TypeDataBaseDTO BaseType{ get; set; }
        public List<TypeDataBaseDTO> GenericArguments{ get; set; }
        public Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO> Modifiers{ get; set; }
        public TypeKindDataBaseDTO TypeKind1{ get; set; }
        public List<TypeDataBaseDTO> ImplementedInterfaces{ get; set; }
        public List<TypeDataBaseDTO> NestedTypes{ get; set; }
        public List<PropertyDataBaseDTO> Properties{ get; set; }
        public TypeDataBaseDTO DeclaringType{ get; set; }
        public List<MethodDataBaseDTO> Methods{ get; set; }
        public List<MethodDataBaseDTO> Constructors{ get; set; }
        public List<ParameterDataBaseDTO> Fields{ get; set; }
    }
}