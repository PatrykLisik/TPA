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
        public virtual int TypeId { get; set; }
        public virtual string TypeName{ get; set; }
        public virtual string NamespaceName{ get; set; }
        public virtual TypeDataBaseDTO BaseType{ get; set; }
        public virtual ICollection<TypeDataBaseDTO> GenericArguments{ get; set; }
        public virtual Tuple<AccessLevelDataBaseDTO, SealedEnumDataBaseDTO, AbstractEnumDataBaseDTO> Modifiers{ get; set; }
        public virtual TypeKindDataBaseDTO TypeKind1{ get; set; }
        public virtual ICollection<TypeDataBaseDTO> ImplementedInterfaces{ get; set; }
        public virtual ICollection<TypeDataBaseDTO> NestedTypes{ get; set; }
        public virtual ICollection<PropertyDataBaseDTO> Properties{ get; set; }
        public virtual TypeDataBaseDTO DeclaringType{ get; set; }
        public virtual ICollection<MethodDataBaseDTO> Methods{ get; set; }
        public virtual ICollection<MethodDataBaseDTO> Constructors{ get; set; }
        public virtual ICollection<ParameterDataBaseDTO> Fields{ get; set; }
    }
}