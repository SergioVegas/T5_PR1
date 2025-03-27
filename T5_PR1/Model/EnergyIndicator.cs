using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T5_PR1.Model
{
   
    [Table("IndicadorEnergia")]
    public class EnergyIndicator
    {
            private const string msgForm = "Aquest camp es obligatori.";
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required(ErrorMessage = msgForm)]
            public int? Any { get; set; }
            [Required(ErrorMessage = msgForm)]
            public double ProduccioNeta { get; set; }
            [Required(ErrorMessage = msgForm)]
            public double? ConsumGasolina { get; set; }
            [Required(ErrorMessage = msgForm)]
            public double? DemandaElectrica { get; set; }
            [Required(ErrorMessage = msgForm)]
            public double? ProduccioDisponible { get; set; }
    }
}
