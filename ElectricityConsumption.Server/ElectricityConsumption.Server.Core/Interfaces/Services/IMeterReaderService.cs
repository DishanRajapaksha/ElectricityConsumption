using ElectricityConsumption.Protos;

namespace ElectricityConsumption.Server.Core.Interfaces.Services;

public interface IMeterReaderService
{
    public Task<MeterUsageResponse> Get(MeterUsageReadRequest request);
}