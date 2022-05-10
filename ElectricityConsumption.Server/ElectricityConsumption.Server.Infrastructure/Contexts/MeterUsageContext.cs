using ElectricityConsumption.Protos;
using ElectricityConsumption.Server.Infrastructure.FluentConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ElectricityConsumption.Server.Infrastructure.Contexts;

public class MeterUsageContext : DbContext
{
    public DbSet<MeterReading> MeterReadings => Set<MeterReading>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={GetDatabasePath()}");

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new MeterReadingConfiguration());

    private static string GetDatabasePath()
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "electricity.db");
    }
}
