namespace HA.LightningService.ConBeeConnector;

public sealed class ConBeeOptions
{
    public const string Section = "ConBee";
    public string Url { get; set; }
    public string ApiKey { get; set; }
    public string Source { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}