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
        public int TypeId { get; set; }
        public string TypeName{ get; set; }
        public string NamespaceName{ get; set; }
        public TypeDataBaseDTO BaseType{ get; set; }
        public ICollection<TypeDataBaseDTO> GenericArguments{ get; set; }
        public Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO> Modifiers{ get; set; }
        public TypeKindDataBaseDTO TypeKind1{ get; set; }
        public ICollection<TypeDataBaseDTO> ImplementedInterfaces{ get; set; }
        public ICollection<TypeDataBaseDTO> NestedTypes{ get; set; }
        public ICollection<PropertyDataBaseDTO> Properties{ get; set; }
        public TypeDataBaseDTO DeclaringType{ get; set; }
        public ICollection<MethodDataBaseDTO> Methods{ get; set; }
        public ICollection<MethodDataBaseDTO> Constructors{ get; set; }
        public ICollection<ParameterDataBaseDTO> Fields{ get; set; }
    }
}