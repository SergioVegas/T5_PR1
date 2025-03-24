using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace T5_PR1.Model
{
    public static class UsingFiles
    {  /// <summary>
       /// Llegeix una llista d'objectes de tipus T des d'un fitxer CSV.
       /// </summary>
       /// <typeparam name="T">El tipus d'objecte a deserialitzar.</typeparam>
       /// <param name="filePath">El camí al fitxer CSV.</param>
       /// <param name="config">Configuració opcional per al lector CSV. Si és null, s'utilitzarà una configuració per defecte amb el delimitador ",".</param>
       /// <returns>Una llista d'objectes de tipus T deserialitzats del fitxer CSV.</returns>
       /// <exception cref="Exception">Es llança si hi ha un error durant la lectura del fitxer CSV.</exception>
        public static class CsvHelperTool
        {
            public static List<T> ReadCsvFile<T>(string filePath, CsvConfiguration? config = null)
            {
                try
                {
                   
                    var csvConfig = config ?? new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," };

                    using (var reader = new StreamReader(filePath))
                    
                    using (var csv = new CsvHelper.CsvReader(reader, csvConfig))
                    {
                        var records = csv.GetRecords<T>().ToList();
                        return records;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error lleguint l'arxiu CSV : {ex.Message}");
                    throw; 
                }
            }
        }

    }

}
