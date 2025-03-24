using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5._PR1._Practica_1.EnegyClass
{
    public class HidroelectricSystem : EnergySystem
    {

        [Required, Range(20, double.MaxValue, ErrorMessage = "El caudal de l'aigua no pot ser menor a 20, torna a introduir un número.")]
        public double WaterFlow { set; get; }
        //Constructor amb més càrrega lògica
        public HidroelectricSystem(double waterFlow, DateTime date, TypeEnergy name, double costEnergy, double priceEnergy, double rati, double generatedEnergy, double totalCost, double totalPrice) : base(date, name, costEnergy, priceEnergy, rati, generatedEnergy, totalCost, totalPrice)
        {
            WaterFlow = waterFlow;
        }
        public HidroelectricSystem() { }

        /// <summary>
        /// Calcula la energia generda d'un sitema d'enegia hidroelectric
        /// </summary>
        /// <returns>Energia calculada</returns>
        public override double CalculateEnergy() => Math.Round(WaterFlow * 9.8 * Rati, 2);

    }
}
