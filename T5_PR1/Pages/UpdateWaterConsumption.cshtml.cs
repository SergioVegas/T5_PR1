using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Data;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class UpdateWaterConsumptionModel : PageModel
    {
        private readonly ILogger<UpdateWaterConsumptionModel> _logger;
        private readonly ApplicationDbContext _context;

        public UpdateWaterConsumptionModel(ILogger<UpdateWaterConsumptionModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public WaterConsumption WaterConsumptions { get; set; }

        public void OnGet(int? id)
        {
            if (id == null || _context.WaterConsumptions == null)
            {
                ModelState.AddModelError(string.Empty, "Error, id null");
            }
            var waterConsumption = _context.WaterConsumptions.FirstOrDefault(e => e.Id == id);
            WaterConsumptions = waterConsumption;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error, al inserir dades");
            }
            _context.WaterConsumptions.Update(WaterConsumptions);
            _context.SaveChanges();
            return RedirectToPage("/WaterConsumption");
        }
    }
}
