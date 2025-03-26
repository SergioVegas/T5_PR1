using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T5_PR1.Model
{
    public class Simulation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Name("DataSimulacio")]
        public DateTime DateSimulation { get; set; }
        [Name("EnergiaNecessaria")]
        public double EnergyNeeded { get; set; }
        [Name("CostEnergetic")]
        public double CostEnergy { get; set; }
        [Name("PreuEnergia")]
        public double PriceEnergy { get; set; }
        [Name("Rati")]
        public double Rati { get; set; }
        [Name("EnergiaGenerada")]
        public double GeneratedEnergy { get; set; }
    }
}
