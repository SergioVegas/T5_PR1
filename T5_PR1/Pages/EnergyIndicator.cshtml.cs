using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Data;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class EnergyIndicatorModel : PageModel
    {
        private readonly ILogger<EnergyIndicatorModel> _logger;
        private readonly ApplicationDbContext _context;

        public EnergyIndicatorModel(ILogger<EnergyIndicatorModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public List<EnergyIndicator> EnergeticIndicators { get; set; } = new List<EnergyIndicator>();
        public List<EnergyIndicator> CurrentPageEnergeticIndicators { get; set; } = new List<EnergyIndicator>();

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public int TotalPages { get; set; }

        public void OnGet(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                PageNumber = pageNumber.Value;
            }

            try
            {
                EnergeticIndicators = _context.EnergyIndicators.ToList(); 
                TotalPages = (int)Math.Ceiling((double)EnergeticIndicators.Count / PageSize);

                //Obte les daes de la p�gina actual
                CurrentPageEnergeticIndicators = EnergeticIndicators
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
            var energyIndicator = _context.EnergyIndicators.Find(id);
            try
            {
                _context.EnergyIndicators.Remove(energyIndicator);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminant l'indicador energetic amb ID {Id}", id);
                ModelState.AddModelError(string.Empty, "Error eliminant l'indicador energetic: " + ex.Message);
            }

            return RedirectToPage("./EnergyIndicator", new { pageNumber = PageNumber });
        }
    }
}
