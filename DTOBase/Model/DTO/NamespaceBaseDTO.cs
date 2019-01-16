using System.Collections.Generic;

namespace Model.DTO
{
    public class NamespaceBaseDTO
    {
        public string NamespaceName;
        public IEnumerable<TypeBaseDTO> Types;
    }
}