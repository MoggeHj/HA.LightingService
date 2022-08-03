using HA.LightningService.ConBeeConnector.Models;

namespace HA.LightningService.RabbitMq.Consumers;

public class SetLightStatusMessageConsumer : BaseConsumer<Light>
{
    private static string _exchangeName = "SetLightStatusMessage";

    public SetLightStatusMessageConsumer() : base(_exchangeName) { }

}