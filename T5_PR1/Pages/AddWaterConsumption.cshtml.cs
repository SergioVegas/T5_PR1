using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using T4_PR1.Model;

namespace T4_PR1.Pages
{
    public class AddWaterConsumptionModel : PageModel
    {
        private readonly ILogger<AddWaterConsumptionModel> _logger;
        private static readonly string XmlFilePath = Path.Combine("ModelData", "water_consumption_data.xml"); //Utiltzo path.combine, per fer aquesta part per millorar la portabilitat del codi.
        public AddWaterConsumptionModel(ILogger<AddWaterConsumptionModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public WaterConsumption WaterConsumption { get; set; }
        public WaterConsumption NewWaterConsumption { get; set; } = new WaterConsumption();
        public string Message { get; set; } //variable per donar més detalls als errors
      

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {               
                return Page();
            }

            try
            {
                XDocument doc;

                if (System.IO.File.Exists(XmlFilePath))
                {
                    doc = XDocument.Load(XmlFilePath);
                }
                else
                {
                    doc = new XDocument(
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("Consums")
                    );
                }             
                XElement newConsum = new XElement("Consum",
                   new XElement("Any", WaterConsumption.Year),
                   new XElement("CodiComarca", WaterConsumption.RegionCode),
                   new XElement("Comarca", WaterConsumption.Region),
                   new XElement("Poblacio", WaterConsumption.Population),
                   new XElement("DomesticXarxa", WaterConsumption.DomesticNet),
                   new XElement("ActivitatsEconomiquesIFontsPropies", WaterConsumption.EconomyActivity),
                   new XElement("Total", WaterConsumption.Total),
                   new XElement("ConsumDomesticPerCapita", WaterConsumption.DomesticConsumptionCapita));

               
                doc.Root.Add(newConsum);

                doc.Save(XmlFilePath);

                return RedirectToPage("/WaterConsumption");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar l'archiu XML.");
                Message = "Error al guardar consum d'aigua.";
                return Page();
            }
        }
    }
}
