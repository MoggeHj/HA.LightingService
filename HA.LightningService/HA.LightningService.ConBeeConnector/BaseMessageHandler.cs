using HA.LightningService.ConBeeConnector.Interfaces;

namespace HA.LightningService.ConBeeConnector;

public abstract class BaseMessageHandler<TMessage> : IMessageHandler
{
    protected readonly IMessageSubscriber<TMessage> _messageSubscriber;

    protected BaseMessageHandler(IMessageSubscriber<TMessage> messageSubscriber)
    {
        _messageSubscriber = messageSubscriber;
    }

    public void Subscribe()
    {
        _messageSubscriber.Subscribe(OnMessageReceived);
    }

    protected abstract void OnMessageReceived(TMessage message);

}