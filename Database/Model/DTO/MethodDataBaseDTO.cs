using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class MethodDataBaseDTO
    {
        [Key]
        public int MethodId {get; set;}
        public string Name{ get; set; }
        public List<TypeDataBaseDTO> GenericArguments{ get; set; }
        public Tuple<AccessLevelDataBaseDTO, AbstractEnumDataBaseDTO, StaticEnumDataBaseDTO, VirtualEnumDataBaseDTO> Modifiers{ get; set; }
        public TypeDataBaseDTO ReturnType{ get; set; }
        public bool Extension{ get; set; }
        public List<ParameterDataBaseDTO> Parameters{ get; set; }

    }
}