using System.Collections.Generic;

namespace Model.DTO
{
    public class AssemblyBaseDTO
    {
        public string Name;
        public IEnumerable<NamespaceBaseDTO> Namespaces;
    }
}