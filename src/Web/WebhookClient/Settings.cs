namespace WebhookClient;

public class Settings
{
    public string Token { get; set; }
    public string IdentityUrl { get; set; } = "http://localhost:55105";
    public string CallBackUrl { get; set; }
    public string WebhooksUrl { get; set; } 
    public string SelfUrl { get; set; }

    public bool ValidateToken { get; set; }

}
