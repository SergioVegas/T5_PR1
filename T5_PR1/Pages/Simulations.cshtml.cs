using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Xml.Linq;
using T5_PR1.Data;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class SimulationsModel : PageModel
    {
        private readonly ILogger<SimulationsModel> _logger;
        private readonly ApplicationDbContext _context;

        public SimulationsModel(ILogger<SimulationsModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
                Simulations = _context.Simulations.ToList();
                TotalPages = (int)Math.Ceiling((double)Simulations.Count / PageSize);

                //Obte les daes de la pàgina actual
                CurrentPageSimulations = Simulations
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error carregant les dades.");
                ModelState.AddModelError(string.Empty, "Error carregant less dades: " + ex.Message);
            }
        }
    }
}
