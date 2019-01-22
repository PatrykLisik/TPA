using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class NamespaceDataBaseDTO
    {
        [Key]
        public virtual int NamespaceId { get; set; }
        public virtual string NamespaceName { get; set; }
        public virtual ICollection<TypeDataBaseDTO> Types { get; set; }
    }
}