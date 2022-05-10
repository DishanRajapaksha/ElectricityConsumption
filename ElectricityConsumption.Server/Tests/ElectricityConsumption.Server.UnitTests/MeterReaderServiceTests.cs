using System.Collections.Generic;
using System.Threading.Tasks;
using ElectricityConsumption.Protos;
using ElectricityConsumption.Server.Core.Interfaces.Repositories;
using ElectricityConsumption.Server.Core.Services;
using Moq;
using Xunit;

namespace ElectricityConsumption.Server.UnitTests;

public class MeterReaderServiceTests
{
	[Fact]
	public async Task Get()
	{
		// Arrange
		var repositoryMock = new Mock<IMeterUsageRepository>();
		var meterUsageRequest = new MeterUsageReadRequest
		{
			PageIndex = 1,
			PageSize = 20
		};
		var meterUsageResponse = new MeterUsageResponse
		{
			PageIndex = 1,
			PageSize = 1,
			Total = 100,
			PageTotal = 100,
			Usage =
			{
				new List<MeterReading>
				{
					new()
					{
						Time = "05/08/2022 12:00",
						MeterUsage = 10.5
					}
				}
			}
		};
		
		repositoryMock
			.Setup(r => r.Get(meterUsageRequest))
			.ReturnsAsync(() => meterUsageResponse);

		var meterReaderService = new MeterReaderService(repositoryMock.Object);

		// Act
		var response = await meterReaderService.Get(meterUsageRequest);

		// Assert
		repositoryMock.Verify(r => r.Get(meterUsageRequest));
		
		Assert.Equal(1, response.PageIndex);
	}
}