using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Data;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class AddEnergyIndicatorModel : PageModel
    {
        private readonly ILogger<AddEnergyIndicatorModel> _logger;
        private readonly ApplicationDbContext _context;
        public AddEnergyIndicatorModel(ILogger<AddEnergyIndicatorModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public EnergyIndicator energyIndicator { get; set; }
        public string Message { get; set; } //variable per donar m�s detalls als errors


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            try
            {
                _context.EnergyIndicators.Add(energyIndicator);
                _context.SaveChanges();
                return RedirectToPage("/EnergyIndicator");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al inserir les dades.");
                Message = "Error al inserir les dades.";
                return Page();
            }
        }
    }
}
