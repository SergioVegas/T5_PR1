using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Data;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class UpdateEnergyIndicatorlModel : PageModel
    {
        private readonly ILogger<UpdateEnergyIndicatorlModel> _logger;
        private readonly ApplicationDbContext _context;

        public UpdateEnergyIndicatorlModel(ILogger<UpdateEnergyIndicatorlModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public EnergyIndicator EnergyIndicators {  get; set; }

        public void OnGet(int? id)
        {
            if(id==null || _context.EnergyIndicators == null)
            {
                ModelState.AddModelError(string.Empty, "Error, id null");
            }
            var energyIndicator = _context.EnergyIndicators.FirstOrDefault(e=> e.Id == id);
            EnergyIndicators = energyIndicator;
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error, al inserir dades");
            }
            _context.EnergyIndicators.Update(EnergyIndicators);
            _context.SaveChanges();
            RedirectToPage("/EnergyIndicator");
        }
    }
}
