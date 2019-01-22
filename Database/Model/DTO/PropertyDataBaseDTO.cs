using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class PropertyDataBaseDTO
    {
        [Key]
        public virtual int PropertyId { get; set; }
        public virtual string Name{ get; set; }
        public virtual TypeDataBaseDTO TypeMetadata{ get; set; }
    }
}