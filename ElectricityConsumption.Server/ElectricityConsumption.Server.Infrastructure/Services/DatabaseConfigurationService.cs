using CsvHelper;
using CsvHelper.Configuration;
using ElectricityConsumption.Server.Infrastructure.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using ElectricityConsumption.Protos;

namespace ElectricityConsumption.Server.Infrastructure.Services;

public static class DatabaseConfigurationService
{
    private static string GetPath()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "meterusage.csv");

        return path;
    }

    public static IEnumerable<MeterReading> GetSeedData()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
            IgnoreBlankLines = true,
            TrimOptions = TrimOptions.Trim,
            ShouldSkipRecord = row =>
            {
                return row.Record.Any(x => string.IsNullOrWhiteSpace(x) || x?.ToString() == "NaN");
            }
        };

        var path = GetPath();

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);
        var records = csv.GetRecords<MeterReading>().ToList();

        return records;
    }

    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MeterUsageContext>();
        context.Database.Migrate();
    }

    public static void SeedDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MeterUsageContext>();
        var hasData = HasSeedData(context);
        if (hasData) return;
        var records = GetSeedData();
        context.MeterReadings.AddRange(records);
        context.SaveChanges();
    }

    // Don't migrate when there's data in the database.
    public static bool HasSeedData(MeterUsageContext context)
    {
        return context.MeterReadings.Any();
    }

    public static void ConfigureDatabase(this IApplicationBuilder app)
    {
        app.MigrateDatabase();
        app.SeedDatabase();
    }
}
