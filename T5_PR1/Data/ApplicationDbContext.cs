using Microsoft.EntityFrameworkCore;
using T5_PR1.Model;

namespace T5_PR1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }
        public DbSet<Simulation> Simulations { get; set; }
        public DbSet<EnergyIndicator> EnergyIndicators { get; set; }
        public DbSet<WaterConsumption> WaterConsumptions { get; set; }

        
    }
}
