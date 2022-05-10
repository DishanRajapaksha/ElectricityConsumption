using ElectricityConsumption.Server.Core.Interfaces.Repositories;
using ElectricityConsumption.Protos;
using ElectricityConsumption.Server.Infrastructure.Contexts;
using ElectricityConsumption.Server.Infrastructure.Extensions;

namespace ElectricityConsumption.Server.Infrastructure.Repositories;

public class MeterUsageSqLiteRepository : IMeterUsageRepository
{
    private readonly MeterUsageContext _context;

    public MeterUsageSqLiteRepository(MeterUsageContext context) => _context = context;

    public async Task<MeterUsageResponse> Get(MeterUsageReadRequest request)
    {
        var meterUsageResponse = await EntityFramework.Paginate(_context.MeterReadings.OrderBy(x => x.Time), request);

        return meterUsageResponse;
    }
    
    public int Count()
    {
        return _context.MeterReadings.Count();
    }
}
