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
	public async Task<ActionResult> GetClaims([FromQuery] MeterUsageReadRequest request)
	{
		var response = await _electricityConsumptionService.GetConsumption(request);
		
		return Ok(response);
	}
}
