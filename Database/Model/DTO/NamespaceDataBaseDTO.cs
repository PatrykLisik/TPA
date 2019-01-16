using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class NamespaceDataBaseDTO
    {
        [Key]
        public string NamespaceName { get; set; }
        public IEnumerable<TypeDataBaseDTO> Types { get; set; }
    }
}