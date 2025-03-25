using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T5_PR1.Models
{
    [Table("IndicadorEnergia")]
    public class EnergyIndicatorModel
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public int? Any { get; set; }
            public double ProduccioNeta { get; set; }
            public double? ConsumGasolina { get; set; }
            public double? DemandaElectrica { get; set; }
            public double? ProduccioDisponible { get; set; }

        }
    }
}
