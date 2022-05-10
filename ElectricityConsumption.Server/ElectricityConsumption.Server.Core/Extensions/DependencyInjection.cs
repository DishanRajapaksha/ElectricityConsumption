using ElectricityConsumption.Server.Core.Interfaces.Services;
using ElectricityConsumption.Server.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityConsumption.Server.Core.Extensions;

public static class DependencyInjection
{
    public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMeterReaderService, MeterReaderService>();
    }
}
