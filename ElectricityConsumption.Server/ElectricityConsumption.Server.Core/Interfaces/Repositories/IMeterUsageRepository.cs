using ElectricityConsumption.Protos;

namespace ElectricityConsumption.Server.Core.Interfaces.Repositories;
public interface IMeterUsageRepository
{
    public Task<MeterUsageResponse> Get(MeterUsageReadRequest request);
}
