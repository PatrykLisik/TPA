using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class AssemblyDataBaseDTO
    {
        [Key]
        public virtual int AssemblyId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<NamespaceDataBaseDTO> Namespaces { get; set; }
    }
}