using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class AssemblyDataBaseDTO
    {
        [Key]
        public string Name { get; set; }
        public List<NamespaceDataBaseDTO> Namespaces { get; set; }
    }
}