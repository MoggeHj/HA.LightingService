using HA.LightningService;
using HA.LightningService.ConBeeConnector;
using Microsoft.Extensions.Http;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
    {
        configurationBuilder.AddJsonFile("Config.json");
    })
    .ConfigureServices((hostcontext, services) =>
    {
      
        services.AddConBeeConnector(hostcontext.Configuration);

        services.AddHostedService<Worker>();
    })
    .Build();


await host.RunAsync();
