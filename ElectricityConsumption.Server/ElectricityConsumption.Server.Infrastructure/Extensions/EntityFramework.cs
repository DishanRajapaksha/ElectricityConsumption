using ElectricityConsumption.Protos;
using Microsoft.EntityFrameworkCore;

namespace ElectricityConsumption.Server.Infrastructure.Extensions;

public static class EntityFramework
{
	public static async Task<MeterUsageResponse> Paginate(IOrderedQueryable<MeterReading> meterReadings, MeterUsageReadRequest request)
	{
		var usage = await meterReadings.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
		var response = new MeterUsageResponse
		{
			Total = meterReadings.Count(),
			Usage = {usage},
			PageIndex = request.PageIndex,
			PageSize = request.PageSize,
			PageTotal =  (int)Math.Ceiling( meterReadings.Count() / (double)request.PageSize),
		};

		return response;
	}
}