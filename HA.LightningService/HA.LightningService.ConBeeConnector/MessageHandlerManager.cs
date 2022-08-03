using HA.LightningService.ConBeeConnector.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HA.LightningService.ConBeeConnector;

public class MessageHandlerManager : IMessageHandlerManager
{
    private readonly IServiceProvider _serviceProvider;

    public MessageHandlerManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Initialize()
    {
        var messageHandlers = _serviceProvider.GetServices<IMessageHandler>();
        foreach (var messageHandler in messageHandlers)
        {
            messageHandler.Subscribe();
        }
    }
}