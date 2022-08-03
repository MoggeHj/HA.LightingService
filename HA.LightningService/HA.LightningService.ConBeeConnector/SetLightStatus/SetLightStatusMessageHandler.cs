using HA.LightningService.ConBeeConnector.Interfaces;
using HA.LightningService.ConBeeConnector.Models;

namespace HA.LightningService.ConBeeConnector.SetLightStatus
{
    public class SetLightStatusMessageHandler : BaseMessageHandler<Light>
    {
        public SetLightStatusMessageHandler(IMessageSubscriber<Light> messageSubscriber): base(messageSubscriber)
        {
        }

        protected override void OnMessageReceived(Light message)
        {
            throw new NotImplementedException();
        }
    }
}
