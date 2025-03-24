using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Xml.Linq;
using T4_PR1.Model;
using T4_PR1.Model.EnergyClasses;

namespace T4_PR1.Pages
{
    public class SimulationsModel : PageModel
    {
         private readonly ILogger<SimulationsModel> _logger;
        public SimulationsModel(ILogger<SimulationsModel> logger)
        {
            _logger = logger;
        }
        public List<Simulation> Simulations { get; set; } = new List<Simulation>();
        public List<Simulation> CurrentPageSimulations { get; set; } = new List<Simulation>(); // Dades de la pàgina actual
        public int PageNumber { get; set; } = 1; // Pàgina actual del registres
        public int PageSize { get; set; } = 50;
        public int TotalPages { get; set; }
        public Simulation HeaderRow { get; set; } = new Simulation();
        public void OnGet(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                PageNumber = pageNumber.Value;
            }

            string filePathCsv = Path.Combine("ModelData", "simulations.csv");
  
            try
            {
                Simulations = UsingFiles.CsvHelperTool.ReadCsvFile<Simulation>(filePathCsv);

                TotalPages = (int)Math.Ceiling((double)Simulations.Count / PageSize);

                // Obte les dades de la pagina actual
                CurrentPageSimulations = Simulations
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();
                HeaderRow = CurrentPageSimulations.FirstOrDefault() ?? new Simulation(); //  Assegurem que sempre hi hagui una capçalera, agafant la primera linea del archiu o tornant una nova instancia


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al llegir l'archiu CSV.");
                ModelState.AddModelError(string.Empty, "Error al carrega les dades.");
            }
        }
    }
}
