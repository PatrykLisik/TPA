using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class PropertyDataBaseDTO
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name{ get; set; }
        public TypeDataBaseDTO TypeMetadata{ get; set; }
    }
}