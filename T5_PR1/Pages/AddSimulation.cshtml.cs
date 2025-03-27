using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using T5_PR1.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T5_PR1.Pages
{
    public class AddSimulationModel : PageModel
    {

        public IActionResult OnPost()
        {
            Simulation simulacio= null;
           
            System.IO.Directory.CreateDirectory("Files");


            return RedirectToPage("/Simulations");

        }
    }
}
