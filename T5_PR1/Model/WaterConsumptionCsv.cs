using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace T5_PR1.Model
{         
    public class WaterConsumptionCsv
    {
       
        [Name("Any")]
        [Required(ErrorMessage = "L'any és obligatori.")]
        public int Year { get; set; }
      
        [Name("Codi comarca")]
        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
        public int RegionCode { get; set; }

        [Name("Comarca")]
        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
        public string? Region { get; set; }

        [Name("Població")]
        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
        public int Population { get; set; }

        [Name("Domèstic xarxa")]
        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
        public double DomesticNet { get; set; }

        [Name("Activitats econòmiques i fonts pròpies")]
        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
        public double EconomyActivity { get; set; }

        [Name("Total")]
        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
        [Name("Consum domèstic per càpita")]
        public double DomesticConsumptionCapita { get; set; }

        public override string ToString()
        {
            return $"Any: {Year}, Comarca: {Region}, Població: {Population}, Total: {Total}";
        }
    }
}
