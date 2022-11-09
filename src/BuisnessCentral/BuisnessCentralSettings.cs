namespace BuisnessCentral
{
    public class BuisnessCentralSettings
    {
        public string EventBusConnection { get; set; } = string.Empty;

        public bool UseCustomizationData { get; set; }

        public bool AzureStorageEnabled { get; set; }
    }
}
