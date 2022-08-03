using HA.LightningService.ConBeeConnector.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HA.LightningService.ConBeeConnector;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddConBeeConnector(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConBeeOptions>(configuration.GetSection(ConBeeOptions.Section));
        services.AddHttpClient<IDataProvider, ConBeeClient>();
        services.AddHttpClient<IAccessToken, AccessTokenClient>();
            
        return services;
    }

}