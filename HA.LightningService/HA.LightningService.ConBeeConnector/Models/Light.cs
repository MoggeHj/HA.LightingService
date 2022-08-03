namespace HA.LightningService.ConBeeConnector.Models;

public class Light
{
    public string Id { get; set; }
    public string UniqueId { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public State State { get; set; }
    public string eTag { get; set; } //HTTP etag which changes on any action to the light.

}