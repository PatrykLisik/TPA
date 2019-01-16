using System.Collections.Generic;

namespace Model.DTO
{
    public class AssemblyBaseDTO
    {
        public string Name { get; set; }
        public IEnumerable<NamespaceBaseDTO> Namespaces { get; set; }
    }
}