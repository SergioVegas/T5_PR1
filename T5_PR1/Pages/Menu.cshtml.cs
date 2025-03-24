using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace T4_PR1.Pages
{
    public class MenuModel : PageModel
    {
        private readonly ILogger<MenuModel> _logger;

        //
        public string TitleMessage { get; set; }
        //

        public MenuModel(ILogger<MenuModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
            TitleMessage = "EcoEnergy Solutions";
            
        }
    }
}
