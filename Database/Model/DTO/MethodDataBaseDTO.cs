using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.DTO
{
    public  class MethodDataBaseDTO
    {
        [Key]
        public virtual int MethodId {get; set;}
        public virtual string Name{ get; set; }
        public virtual ICollection<TypeDataBaseDTO> GenericArguments{ get; set; }
        public virtual Tuple<AccessLevelDataBaseDTO, AbstractEnumDataBaseDTO, StaticEnumDataBaseDTO, VirtualEnumDataBaseDTO> Modifiers{ get; set; }
        public virtual TypeDataBaseDTO ReturnType{ get; set; }
        public virtual bool Extension{ get; set; }
        public virtual ICollection<ParameterDataBaseDTO> Parameters{ get; set; }

    }
}