using System.ComponentModel.DataAnnotations;

namespace Model.DTO
{
    public class ParameterDataBaseDTO
    {
        [Key]
        public virtual int ParameterId { get; set; }
        public virtual string Name{ get; set; }
        public virtual TypeDataBaseDTO TypeMetadata{ get; set; }
    }
}