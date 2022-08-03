using HA.LightningService.ConBeeConnector;
using HA.LightningService.ConBeeConnector.Interfaces;
using HA.LightningService.ConBeeConnector.Models;
using HA.LightningService.ConBeeConnector.SetLightStatus;
using HA.LightningService.RabbitMq.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
    {
        configurationBuilder.AddJsonFile("Config.json");
    })
    .ConfigureServices((hostcontext, services) =>
    {
        services.AddConBeeConnector(hostcontext.Configuration);
        services.AddSingleton<IMessageSubscriber<Light>, SetLightStatusMessageConsumer>();
        services.AddSingleton<IMessageHandler, SetLightStatusMessageHandler>();
        services.AddSingleton<IMessageHandlerManager, MessageHandlerManager>();

    })
    .Build();



var serviceProvider = host.Services;
    var myService = serviceProvider.GetServices<IMessageHandlerManager>();

    foreach (var messageHandlerManager in myService)
    {
        messageHandlerManager.Initialize();
    }




host.Run();




