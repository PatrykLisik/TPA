using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class NamespaceDataBaseDTO
    {
        [Key]
        public int NamespaceId { get; set; }
        public string NamespaceName { get; set; }
        public ICollection<TypeDataBaseDTO> Types { get; set; }
    }
}