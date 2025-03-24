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
        public DateTime DateSimulation { get; set; }
        public TypeEnergy EnergyType { get; set; }
        public double EnergyNeeded { get; set; }
        public double CostEnergy { get; set; }
        public double PriceEnergy { get; set; }
        public double Rati { get; set; }
        public double GeneratedEnergy { get; set; }
        public double TotalPrice { set; get; }
        public double TotalCost { set; get; }
    }
}
