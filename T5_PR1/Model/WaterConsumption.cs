using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T5_PR1.Model
{
    [Table("Consum d'aigua")]
    public class WaterConsumption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Comarca { get; set; }
        public string? Municipi { get; set; }
        public double? Consum { get; set; }
        public int? Any { get; set; }
    }
}
