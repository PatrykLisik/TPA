using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class AssemblyDataBaseDTO
    {
        [Key]
        public int AssemblyId { get; set; }
        public string Name { get; set; }
        public ICollection<NamespaceDataBaseDTO> Namespaces { get; set; }
    }
}