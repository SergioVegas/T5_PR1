using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using T5_PR1.Data;
using T5_PR1.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T5_PR1.Pages
{
    public class AddSimulationModel : PageModel
    {

        private readonly ILogger<AddSimulationModel> _logger;
        private readonly ApplicationDbContext _context;
        public AddSimulationModel(ILogger<AddSimulationModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Simulation simulacio { get; set; }
        public string Message { get; set; } //variable per donar més detalls als errors


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Simulations.Add(simulacio);
                _context.SaveChanges();
                return RedirectToPage("/Simulations");
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
