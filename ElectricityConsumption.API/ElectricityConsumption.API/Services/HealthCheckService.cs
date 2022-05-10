using ElectricityConsumption.Protos;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ElectricityConsumption.API.Services
{
    public class HealthCheckService : IHealthCheck
    {
        private readonly MeterUsageReader.MeterUsageReaderClient _client;

        public HealthCheckService(MeterUsageReader.MeterUsageReaderClient client) => _client = client;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var response = await _client.CheckMeterUsageReaderHealthAsync(new MeterUsageReaderHealthCheckRequest { Service = "MeterUsageService" });

            return response.Status switch
            {
                MeterUsageReaderHealthCheckResponse.Types.MeterUsageReaderServingStatus.Serving => HealthCheckResult.Healthy(),
                MeterUsageReaderHealthCheckResponse.Types.MeterUsageReaderServingStatus.NotServing => HealthCheckResult.Unhealthy(),
                MeterUsageReaderHealthCheckResponse.Types.MeterUsageReaderServingStatus.Unknown => HealthCheckResult.Unhealthy(),
                _ => HealthCheckResult.Unhealthy(),
            };
        }
    }

}
