using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T5_PR1.Model
{
    public class Simulation
    {
        private const string msgForm = "Aquest camp es obligatori.";
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Name("DataSimulacio")]
        [Required(ErrorMessage = msgForm)]
        public DateTime DateSimulation { get; set; }
        [Name("EnergiaNecessaria")]
        [Required(ErrorMessage = msgForm)]
        public double EnergyNeeded { get; set; }
        [Name("CostEnergetic")]
        [Required(ErrorMessage = msgForm)]
        public double CostEnergy { get; set; }
        [Name("PreuEnergia")]
        [Required(ErrorMessage = msgForm)]
        public double PriceEnergy { get; set; }
        [Name("Rati")]
        [Required(ErrorMessage = msgForm)]
        [Range(0.1, 0.3, ErrorMessage = "El rati ha d'estar entre 0.1 y 0.3")]
        public double Rati { get; set; }
        [Name("EnergiaGenerada")]
        [Required(ErrorMessage = msgForm)]
        public double GeneratedEnergy { get; set; }
    }
}
