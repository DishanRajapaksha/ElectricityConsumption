using ElectricityConsumption.Server.Core.Interfaces.Repositories;
using ElectricityConsumption.Server.Infrastructure.Contexts;
using ElectricityConsumption.Server.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityConsumption.Server.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMeterUsageRepository, MeterUsageSqLiteRepository>();

        services.AddDbContext<MeterUsageContext>();
    }
}
