using ElectricityConsumption.API.Core.Interfaces;
using ElectricityConsumption.Protos;
using Microsoft.Extensions.Logging;

namespace ElectricityConsumption.API.Core.Services;
public class ElectricityConsumptionService : IElectricityConsumptionService
{
    private readonly ILogger<ElectricityConsumptionService> _logger;
    private readonly MeterUsageReader.MeterUsageReaderClient _client;
    
    public ElectricityConsumptionService(ILogger<ElectricityConsumptionService> logger, MeterUsageReader.MeterUsageReaderClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async Task<MeterUsageResponse> GetConsumption(MeterUsageReadRequest request)
    {
        var response =  await _client.ReadMeterAsync(request, deadline: DateTime.UtcNow.AddSeconds(10));

        return response;
    }
}
