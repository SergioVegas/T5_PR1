using Microsoft.EntityFrameworkCore;
using T5_PR1.Data;
using T5_PR1.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages();
        app.MapGet("/", () => Results.Redirect("/Menu")); //Aquí he posat la pàgina inicial on ha d'aparèixer quan iniciem el programa.

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                string filePathCsvWaterConsumption = Path.Combine("ModelData", "consum_aigua_cat_per_comarques.csv");
                string filePathCsvEnergyIndicator = Path.Combine("ModelData", "indicadors_energetics_cat.csv");

                Seeding.SeedWaterConsumptions(context, filePathCsvWaterConsumption);
                Seeding.SeedEnergyIndicators(context, filePathCsvEnergyIndicator);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
        app.Run();
    }
}