using ElectricityConsumption.Protos;

namespace ElectricityConsumption.API.Core.Interfaces;
public interface IElectricityConsumptionService
{
    public Task<MeterUsageResponse> GetConsumption(MeterUsageReadRequest request);
}