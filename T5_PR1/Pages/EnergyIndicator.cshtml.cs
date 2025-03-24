using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class EnergyIndicatorModel : PageModel
    {
        private readonly ILogger<EnergyIndicatorModel> _logger;
        public EnergyIndicatorModel(ILogger<EnergyIndicatorModel> logger)
        {
            _logger = logger;
        }
        public List<EnergeticIndicator> EnergeticIndicators { get; set; } = new List<EnergeticIndicator>();
        public List<EnergeticIndicator> CurrentPageEnergeticIndicators { get; set; } = new List<EnergeticIndicator>();
        public List<EnergeticIndicator> EnergeticIndicatorsJson { get; set; } = new List<EnergeticIndicator>();
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public int TotalPages { get; set; }
        // Propietats per less estadistiques
        public List<EnergeticIndicator> produccionOver3000 { get; set; } = new List<EnergeticIndicator>();
        public List<EnergeticIndicator> gasOver100 { get; set; } = new List<EnergeticIndicator>();
        public List<EnergeticIndicator> mitjanaProduccioNetaPerAny { get; set; } = new List<EnergeticIndicator>();
        public List<EnergeticIndicator> electricDemandAndProdcutionAvailable { get; set; } = new List<EnergeticIndicator>();

        public void OnGet(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                PageNumber = pageNumber.Value;
            }

            string filePathCsv = Path.Combine("ModelData", "indicadors_energetics_cat.csv");
            string filePathJson = Path.Combine("ModelData", "indicadors_energetics_cat.json");
            try
            {
                EnergeticIndicators = UsingFiles.CsvHelperTool.ReadCsvFile<EnergeticIndicator>(filePathCsv);
                if(System.IO.File.Exists(filePathJson))
                {

                    UsingFiles.JsonHelperTool.ReadJsonFile(filePathJson, EnergeticIndicatorsJson);
                    //Console.WriteLine("-------------> llegueixo el json");
                }
              
                TotalPages = (int)Math.Ceiling((double)EnergeticIndicators.Count / PageSize);

                EnergeticIndicators.AddRange(EnergeticIndicatorsJson);
                //Obte les daes de la pàgina actual
                CurrentPageEnergeticIndicators = EnergeticIndicators
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

                EnergyIndicatorsAnalisis();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error carregant less dades: " + ex.Message);
            }
        }
        /// <summary>
        /// Funcio per fer les LinQ dels indicaddors d'energia
        /// </summary>
        public void EnergyIndicatorsAnalisis()
        {
            if (EnergeticIndicators == null || EnergeticIndicators.Count == 0)
            {
                return;
            }
            //Registres amb producció neta superior a 3000
            int productionAsked = 3000;
             produccionOver3000 = EnergeticIndicators
                .Where(w => w.CDEEBC_ProdNeta > productionAsked)
                .OrderBy(w => w.CDEEBC_ProdNeta)
                .ToList();
            //Registres amb consum de gasolina superior a 100
            int GasConsumptionAsked = 100;
            gasOver100 = EnergeticIndicators
                .Where(w => w.CCAC_GasolinaAuto > GasConsumptionAsked)
                .OrderByDescending(w => w.CCAC_GasolinaAuto)
                .ToList();
            //Mitjana de producció neta per cada any
            var mitjanaProduccioNetaPerAny = EnergeticIndicators
                .GroupBy(e => e.Data.Substring(3, 4))
                .Select(g => new
                {
                    Any = g.Key,
                    Mitjana = g.Average(e => e.CDEEBC_ProdNeta)
                })
                .OrderBy(a => a.Any)
                .ToList();
            //Registres amb demanda elèctrica superior a 4000 i producció disponible inferior a 300

            int electricDemandAsked = 4000;
            int produccionAvailableAsked = 300;
            electricDemandAndProdcutionAvailable = EnergeticIndicators
            .Where(w => w.CDEEBC_DemandaElectr > electricDemandAsked && w.CDEEBC_ProdDisp < produccionAvailableAsked)
            .ToList();
        }
    }
}
