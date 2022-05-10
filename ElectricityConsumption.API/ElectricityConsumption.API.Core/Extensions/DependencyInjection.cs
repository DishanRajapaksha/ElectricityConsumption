using ElectricityConsumption.API.Core.Interfaces;
using ElectricityConsumption.API.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityConsumption.API.Core.Extensions;

public static class DependencyInjection
{
    public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IElectricityConsumptionService, ElectricityConsumptionService>();
    }
}
