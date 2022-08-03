using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HA.LightningService.ConBeeConnector.Interfaces;
using HA.LightningService.ConBeeConnector.Models;

namespace HA.LightningService.ConBeeConnector;

public class ConBeeClient : IDataProvider
{
    private HttpClient _client;
    private ILogger<ConBeeClient> _logger;

    public ConBeeClient(HttpClient client, ILogger<ConBeeClient> logger, IOptions<ConBeeOptions> config)
    {
        client.BaseAddress = new Uri(config.Value.Url);
        _client=client;
        _logger=logger;
    }


    public Light GetLight(int id)
    {
        throw new NotImplementedException();
    }

    public List<Light> GetLights()
    {
        throw new NotImplementedException();
    }

    public bool SetState(Light light)
    {
        throw new NotImplementedException();
    }

    public bool SetName(Light light)
    {
        throw new NotImplementedException();
    }
}