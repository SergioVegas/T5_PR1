﻿using CsvHelper;
using System.Globalization;
using T5_PR1.Model;
using T5_PR1.Data;

namespace T5_PR1.Model
{
    public static  class Seeding
    {
        public static void SeedEnergyIndicators(ApplicationDbContext context, string csvFilePath)
        {
            context.Database.EnsureCreated();
            // Llegir el csv
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var information = csv.GetRecords<EnergeticIndicatorCsv>().ToList();
                //Afegim a la base de dades els camps que ens interesa
                var energyIndicators = information.Select(r => new EnergyIndicator
                {
                    Any = r.Data?.Year,
                    ProduccioNeta = r.CDEEBC_ProdNeta,
                    ConsumGasolina = r.CCAC_GasolinaAuto,
                    DemandaElectrica = r.CDEEBC_DemandaElectr,
                    ProduccioDisponible = r.CDEEBC_ProdDisp
                }).ToList();

                context.EnergyIndicators.AddRange(energyIndicators);
                context.SaveChanges();
            }
        } 
    }
}
