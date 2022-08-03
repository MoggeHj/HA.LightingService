using HA.LightningService.ConBeeConnector.Models;

namespace HA.LightningService.ConBeeConnector.Interfaces;

public interface IDataProvider
{
    Light GetLight(int id);
    List<Light> GetLights();
    bool SetState(Light light);
    bool SetName (Light light);

    //GetGroups
    //GetGroup
    //SetGroup
    //...

}