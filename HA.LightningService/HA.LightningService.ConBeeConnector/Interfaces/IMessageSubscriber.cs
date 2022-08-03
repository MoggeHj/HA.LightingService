namespace HA.LightningService.ConBeeConnector.Interfaces;

public interface IMessageSubscriber<T>
{
    void Subscribe(Action<T> action);
}