using ElectricityConsumption.Server.Core.Interfaces.Repositories;
using ElectricityConsumption.Server.Core.Interfaces.Services;
using ElectricityConsumption.Protos;

namespace ElectricityConsumption.Server.Core.Services;

public class MeterReaderService : IMeterReaderService
{
    private readonly IMeterUsageRepository _meterUsageRepository;

    public MeterReaderService(IMeterUsageRepository meterUsageRepository) => _meterUsageRepository = meterUsageRepository;

    public async Task<MeterUsageResponse> Get(MeterUsageReadRequest request)
    {
        var paginatedResponse = await _meterUsageRepository.Get(request);

        var meterUsageReply = new MeterUsageResponse
        {
            Usage = { paginatedResponse.Usage.ToList() },
            PageTotal = paginatedResponse.PageTotal,
            PageIndex = paginatedResponse.PageIndex,
            Total = paginatedResponse.Total,
            PageSize = paginatedResponse.PageSize,
        };

        return meterUsageReply;
    }
}
