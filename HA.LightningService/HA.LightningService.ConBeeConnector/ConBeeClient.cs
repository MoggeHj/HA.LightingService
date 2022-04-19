using HA.LightningService.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        

        
}