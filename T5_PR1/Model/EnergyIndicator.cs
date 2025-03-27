using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T5_PR1.Model
{
    [Table("IndicadorEnergia")]
    public class EnergyIndicator
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required(ErrorMessage = "L'any és obligatori.")]
            public int? Any { get; set; }
            public double ProduccioNeta { get; set; }
            public double? ConsumGasolina { get; set; }
            public double? DemandaElectrica { get; set; }
            public double? ProduccioDisponible { get; set; }
    }
}
