using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Data;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class AddWaterConsumptionModel : PageModel
    {
        private readonly ILogger<AddWaterConsumptionModel> _logger;
        private readonly ApplicationDbContext  _context;
        public AddWaterConsumptionModel(ILogger<AddWaterConsumptionModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public WaterConsumption waterConsumption { get; set; }
        public string Message { get; set; } //variable per donar més detalls als errors
      

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.WaterConsumptions.Add(waterConsumption);
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
