using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using T5._PR1._Practica_1.EnegyClass;

namespace T5_PR1.Model.EnergyClasses
{
    public class Simulation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Name("DataSimulacio")]
        public DateTime DateSimulation { get; set; }
        [Name("TipusEnergia")]
        public TypeEnergy EnergyType { get; set; }
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
        [Name("PreuTotal")]
        public double TotalPrice { set; get; }
        [Name("CostTotal")]
        public double TotalCost { set; get; }
    }
}
