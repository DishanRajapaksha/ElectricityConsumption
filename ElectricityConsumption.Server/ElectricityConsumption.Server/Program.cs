using ElectricityConsumption.Server.Core.Extensions;
using ElectricityConsumption.Server.Infrastructure.Extensions;
using ElectricityConsumption.Server.Infrastructure.Services;
using ElectricityConsumption.Server.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
	options.EnableDetailedErrors = true;
});

builder.Services
	.AddGrpcHealthChecks()
	.AddCheck("Sample", () => HealthCheckResult.Healthy());

builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (!builder.Environment.IsProduction())
{
	app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseGrpcWeb();

app.ConfigureDatabase();

app.UseEndpoints(endpoints =>
{
	endpoints.MapGrpcService<MeterUsageReaderService>().EnableGrpcWeb();
});

app.MapGrpcHealthChecksService();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
