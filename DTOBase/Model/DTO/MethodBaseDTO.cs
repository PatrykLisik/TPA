using System;
using System.Collections.Generic;

namespace Model.DTO
{
    public class MethodBaseDTO
    {
        public string Name;
        public IEnumerable<TypeBaseDTO> GenericArguments;
        public Tuple<AccessLevelBaseDTO, AbstractEnumBaseDTO, StaticEnumBaseDTO, VirtualEnumBaseDTO> Modifiers;
        public TypeBaseDTO ReturnType;
        public bool Extension;
        public IEnumerable<ParameterBaseDTO> Parameters;

    }
}