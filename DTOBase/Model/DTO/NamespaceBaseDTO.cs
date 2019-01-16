using System.Collections.Generic;

namespace Model.DTO
{
    public class NamespaceBaseDTO
    {
        public string NamespaceName { get; set; }
        public IEnumerable<TypeBaseDTO> Types { get; set; }
    }
}