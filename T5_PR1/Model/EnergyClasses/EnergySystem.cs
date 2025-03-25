using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T5._PR1.EnergyClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T5._PR1._Practica_1.EnegyClass
{
    public enum TypeEnergy { Solar, Eolica, Hidroelectrica }
    public  class EnergySystem : IEnergyCalculate
    {
        
        public DateTime DateSimulation {  get; set; }
        [Required(ErrorMessage = "No has escollit cap valor!")]
        public TypeEnergy Name { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        public double CostEnergy { get; set; }
        [Required(ErrorMessage = "Aquest camp és obligatori")]
        public double PriceEnergy { get; set; }
        [Range(0.1, 0.3, ErrorMessage = "El rati ha d'estar entre 0.1 y 0.3.")]
        public double Rati { get; set; }
        public double GeneratedEnergy { get;  set; }
        public double TotalPrice { set; get; }
        public double TotalCost { set; get; }
        public  EnergySystem() { }
        public EnergySystem (DateTime date, TypeEnergy name, double costEnergy,double priceEnergy, double rati, double generatedEnergy, double totalCost, double totalPrice) 
        { DateSimulation = date;  Name = name; CostEnergy = costEnergy; PriceEnergy = priceEnergy; Rati = rati; GeneratedEnergy = generatedEnergy; TotalPrice = totalPrice; TotalCost = totalCost; }
     
        public virtual double CalculateEnergy()=>0;
        /// <summary>
        /// Calcula el cost total de l'energia despesa
        /// </summary>
        /// <returns>La quantitat de diners</returns>
        public double CalculateTotalCost() => CostEnergy * GeneratedEnergy;
        /// <summary>
        /// Calcula el preu total de l'energia despesa
        /// </summary>
        /// <returns>La quantitat de diners</returns>
        public double CalculateTotalPrice()=> CostEnergy * PriceEnergy;

    }
}
