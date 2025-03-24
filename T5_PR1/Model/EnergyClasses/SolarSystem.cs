using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace T5._PR1._Practica_1.EnegyClass
{
    public  class SolarSystem : EnergySystem
    {

        [Required, Range(1, double.MaxValue, ErrorMessage = "Les hores de sol no poden ser menors a 1, torna a introduir un número.")] // he intentat posa el missatge en un camp privat, pero no funciona. ex: [Required, Range(1, double.MaxValue, ErrorMessage = nameof(minimumMsg))]
        public double SunHours { set; get; }
        
        
        public SolarSystem() { }
        //Constructor amb més càrrega lògica
        public SolarSystem(double sunHours, DateTime date, TypeEnergy name, double costEnergy, double priceEnergy, double rati, double generatedEnergy, double totalCost, double totalPrice) :base(date, name, costEnergy, priceEnergy, rati, generatedEnergy, totalCost, totalPrice)
        {
            SunHours = sunHours;
        }
        /// <summary>
        /// Calcula la energia generda d'un sitema d'enegia solar
        /// </summary>
        /// <returns>Energia calculada</returns>
        public  override double CalculateEnergy() => Math.Round(SunHours * Rati, 2);
    }
}
