using ElectricityConsumption.Protos;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityConsumption.API.Infrastructure.Extensions;
public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<MeterUsageReader.MeterUsageReaderClient>(options =>
        {
            options.Address = new Uri(configuration.GetSection("SERVER_HOST").Value);
        })
       .ConfigurePrimaryHttpMessageHandler(() =>
       {
           AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

           var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());

           return handler;
       });
    }
}
