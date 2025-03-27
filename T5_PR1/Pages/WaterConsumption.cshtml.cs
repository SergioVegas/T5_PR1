using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Model;
using T5_PR1.Data;

namespace T5_PR1.Pages
{
    public class WaterConsumptionModel : PageModel
    {
        private readonly ILogger<WaterConsumptionModel> _logger;
        private readonly ApplicationDbContext _context;

        public WaterConsumptionModel(ILogger<WaterConsumptionModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<WaterConsumption> WaterConsumptions { get; set; } = new List<WaterConsumption>();
        public List<WaterConsumption> CurrentPageWaterConsumptions { get; set; } = new List<WaterConsumption>(); // Dades de la pàgina actual
        public int PageNumber { get; set; } = 1; // Pàgina actual del registres
        public int PageSize { get; set; } = 50; 
        public int TotalPages { get; set; } 
        public WaterConsumption HeaderRow { get; set; } = new WaterConsumption();

        public void OnGet(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                PageNumber = pageNumber.Value;
            }

            string filePathCsv = Path.Combine("ModelData", "consum_aigua_cat_per_comarques.csv");
            try
            {
                WaterConsumptions = _context.WaterConsumptions.ToList();
                TotalPages = (int)Math.Ceiling((double)WaterConsumptions.Count / PageSize);

                //Obte les daes de la pàgina actual
                CurrentPageWaterConsumptions = WaterConsumptions
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
        public IActionResult OnPostDelete(int id)
        {
            var waterConsumption =  _context.WaterConsumptions.Find(id);
            try
            {
                _context.WaterConsumptions.Remove(waterConsumption);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminant el consum d'aigua amb ID {Id}", id);
                ModelState.AddModelError(string.Empty, "Error eliminant el consum d'aigua: " + ex.Message);
            }

            return RedirectToPage("./WaterConsumption", new { pageNumber = PageNumber }); 
        }
    }  
}
