using Microsoft.EntityFrameworkCore;
using T5_PR1.Model.EnergyClasses;
using T5_PR1.Models;

namespace T5_PR1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Simulation> Simulations { get; set; }
        public DbSet<EnergyIndicatorModel> EnergyIndicators { get; set; }
        public DbSet<WaterConsumptionModel> WaterConsumptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }
    }
}
