using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Data;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class UpdateSimulationModel : PageModel
    {
        private readonly ILogger<UpdateSimulationModel> _logger;
        private readonly ApplicationDbContext _context;

        public UpdateSimulationModel(ILogger<UpdateSimulationModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public Simulation Simulations { get; set; }

        public void OnGet(int? id)
        {
            if (id == null || _context.Simulations == null)
            {
                ModelState.AddModelError(string.Empty, "Error, id null");
            }
            var simulation = _context.Simulations.FirstOrDefault(e => e.id == id);
            Simulations = simulation;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Error, al inserir dades");
            }
            _context.Simulations.Update(Simulations);
            _context.SaveChanges();
            return RedirectToPage("/Simulations");
        }
    }
}
