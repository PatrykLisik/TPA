using System;
using System.Collections.Generic;

namespace Model.DTO
{
    public class MethodBaseDTO
    {
        public string Name{ get; set; }
        public IEnumerable<TypeBaseDTO> GenericArguments{ get; set; }
        public Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> Modifiers{ get; set; }
        public TypeBaseDTO ReturnType{ get; set; }
        public bool Extension{ get; set; }
        public IEnumerable<ParameterBaseDTO> Parameters{ get; set; }

    }
}