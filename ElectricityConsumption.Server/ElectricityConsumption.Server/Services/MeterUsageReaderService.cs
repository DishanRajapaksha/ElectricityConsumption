using ElectricityConsumption.Server.Core.Interfaces.Services;
using ElectricityConsumption.Protos;
using Grpc.Core;
using static ElectricityConsumption.Protos.MeterUsageReaderHealthCheckResponse.Types;

namespace ElectricityConsumption.Server.Services
{
    public class MeterUsageReaderService : MeterUsageReader.MeterUsageReaderBase
    {
        private readonly ILogger<MeterUsageReaderService> _logger;
        private readonly IMeterReaderService _meterReaderService;

        public MeterUsageReaderService(ILogger<MeterUsageReaderService> logger, IMeterReaderService meterReaderService)
        {
            _logger = logger;
            _meterReaderService = meterReaderService;
        }

        public override async Task<MeterUsageResponse> ReadMeter(MeterUsageReadRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Read Meter Request Received");

            var response = await _meterReaderService.Get(request);
            
            return response;
        }

        public override async Task<MeterUsageReaderHealthCheckResponse> CheckMeterUsageReaderHealth(MeterUsageReaderHealthCheckRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Health Check Request Received");

            return new MeterUsageReaderHealthCheckResponse()
            {
                Status = MeterUsageReaderServingStatus.Serving
            };
        }
    }
}