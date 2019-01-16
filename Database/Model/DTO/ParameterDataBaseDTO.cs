using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class ParameterDataBaseDTO
    {
        [Key]
        public string Name{ get; set; }
        public TypeDataBaseDTO TypeMetadata{ get; set; }
    }
}