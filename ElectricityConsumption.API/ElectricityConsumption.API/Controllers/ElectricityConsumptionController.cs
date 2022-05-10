using ElectricityConsumption.API.Core.Interfaces;
using ElectricityConsumption.Protos;
using Microsoft.AspNetCore.Mvc;

namespace ElectricityConsumption.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ElectricityConsumptionController : ControllerBase
{
	private readonly ILogger<ElectricityConsumptionController> _logger;
	private readonly IElectricityConsumptionService _electricityConsumptionService;

	public ElectricityConsumptionController(ILogger<ElectricityConsumptionController> logger, IElectricityConsumptionService electricityConsumptionService)
	{
		_logger = logger;
		_electricityConsumptionService = electricityConsumptionService;
	}
	
	[HttpGet]
	public async Task<ActionResult> GetConsumption([FromQuery] MeterUsageReadRequest request)
	{
		_logger.LogInformation("Get Consumption Request");
		
		var response = await _electricityConsumptionService.GetConsumption(request);
		
		return Ok(response);
	}
}
