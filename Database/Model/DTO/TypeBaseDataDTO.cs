using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class TypeDataBaseDTO
    {

        public enum TypeKindBaseDTO
        {
            EnumType, StructType, InterfaceType, ClassType
        }
        [Key]
        public string TypeName{ get; set; }
        public string NamespaceName{ get; set; }
        public TypeDataBaseDTO BaseType{ get; set; }
        public IEnumerable<TypeDataBaseDTO> GenericArguments{ get; set; }
        public Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO> Modifiers{ get; set; }
        public TypeKindBaseDTO TypeKind1{ get; set; }
        public IEnumerable<TypeDataBaseDTO> ImplementedInterfaces{ get; set; }
        public IEnumerable<TypeDataBaseDTO> NestedTypes{ get; set; }
        public IEnumerable<PropertyDataBaseDTO> Properties{ get; set; }
        public TypeDataBaseDTO DeclaringType{ get; set; }
        public IEnumerable<MethodDataBaseDTO> Methods{ get; set; }
        public IEnumerable<MethodDataBaseDTO> Constructors{ get; set; }
        public IEnumerable<ParameterDataBaseDTO> Fields{ get; set; }
    }
}