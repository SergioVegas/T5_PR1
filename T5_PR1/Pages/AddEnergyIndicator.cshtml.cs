using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5_PR1.Model;

namespace T5_PR1.Pages
{
    public class AddEnergyIndicatorModel : PageModel
    {
        private readonly ILogger<AddEnergyIndicatorModel> _logger;
      
        public AddEnergyIndicatorModel(ILogger<AddEnergyIndicatorModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public EnergeticIndicator Indicador { get; set; }
        public List<EnergeticIndicator> NewWEnergeticIndicator { get; set; } 
        public string Message { get; set; } //variable per donar més detalls als errors


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string filePathJson = Path.Combine("ModelData", "indicadors_energetics_cat.json"); 
            try
            {

                if (System.IO.File.Exists(filePathJson))
                {
                    string jsonFromFile = System.IO.File.ReadAllText(filePathJson);
                    var deserializedIndicadors = System.Text.Json.JsonSerializer.Deserialize<List<EnergeticIndicator>>(jsonFromFile);
                    NewWEnergeticIndicator = deserializedIndicadors.ToList();
                }
                else
                {
                    NewWEnergeticIndicator = new List<EnergeticIndicator>();
                }
              
                //evitar inserir valors nuls al json
                foreach (var propietat in typeof(EnergeticIndicator).GetProperties())
                {
                    var valorActual = propietat.GetValue(Indicador);
                    if (valorActual == null)
                    {
                        if (propietat.PropertyType == typeof(string))
                            propietat.SetValue(Indicador, "0.0%");
                        else if (propietat.PropertyType == typeof(int))
                            propietat.SetValue(Indicador, 0);
                        else if (propietat.PropertyType == typeof(double))
                            propietat.SetValue(Indicador, 0.0);
                        else if (propietat.PropertyType == typeof(double?))
                            propietat.SetValue(Indicador, 0.0);
                        else if (propietat.PropertyType == typeof(DateTime))
                            propietat.SetValue(Indicador, DateTime.Now);
                    }
                }
                NewWEnergeticIndicator.Add(Indicador);
                UsingFiles.JsonHelperTool.WriteJsonFile(filePathJson, NewWEnergeticIndicator);

                return RedirectToPage("/EnergyIndicator");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar l'archiu JSON.");
                Message = "Error al guardar indicador d'energia.";
                return Page();
            }
        }
    }
}
