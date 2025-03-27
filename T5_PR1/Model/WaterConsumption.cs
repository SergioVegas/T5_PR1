using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T5_PR1.Model
{
    [Table("ConsumAigua")]
    public class WaterConsumption
    {
        private const string msgForm = "Aquest camp es obligatori.";
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = msgForm)]
        public string? Comarca { get; set; }
        [Required(ErrorMessage = msgForm)]
        public int? Municipi { get; set; }
        [Required(ErrorMessage = msgForm)]
        public double? Consum { get; set; }
        [Required(ErrorMessage = msgForm)]
        public int? Any { get; set; }
    }
}
