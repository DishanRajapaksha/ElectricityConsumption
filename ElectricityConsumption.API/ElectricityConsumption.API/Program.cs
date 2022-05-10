using FluentValidation.AspNetCore;
using System.Reflection;
using ElectricityConsumption.API.Core.Extensions;
using ElectricityConsumption.API.Infrastructure.Extensions;
using ElectricityConsumption.API.Services;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// For Development only. CORS policy should be more specific in a production environment.
builder.Services.AddCors(options => options.AddPolicy(name: "AllowAll", policy =>
{
	policy.AllowAnyOrigin();
	policy.AllowAnyMethod();
	policy.AllowAnyHeader();
}));

builder.Services.AddControllers().AddFluentValidation(options =>
{
	options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
	options.ImplicitlyValidateChildProperties = true;
});

builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

#region Logging, Swagger and Health

builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>(typeof(Program).FullName, LogLevel.Trace);
builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);

builder.Services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
{
	EnableAdaptiveSampling = false,
	DeveloperMode = true
});

builder.Services.AddHealthChecks().AddCheck<HealthCheckService>("health_check");

builder.Services.AddSwaggerGen(x => x.SwaggerDoc("v1",
	new OpenApiInfo { Title = "Electricity Consumption", Version = "v1" }));

#endregion

var app = builder.Build();

#region Logging, Swagger and Health

app.UseExceptionHandler(!app.Environment.IsProduction() ? "/error-development" : "/error");

app.UseSwagger();
app.UseSwaggerUI(x =>
{
	x.SwaggerEndpoint("/swagger/v1/swagger.json", "Electricity Consumption");
	x.RoutePrefix = string.Empty;
});

#endregion

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();