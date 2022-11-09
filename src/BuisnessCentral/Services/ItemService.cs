using System.Linq;
using System.Text.Json;

namespace BuisnessCentral.Services
{
    public class ItemService: IItemService
    {
        private readonly HttpClient _httpClient;
        private readonly string catalogUri;
        private readonly IOptions<AppSettings> _settings;

        public ItemService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            catalogUri = $"{_settings.Value.CatalogUrl}/api/v1/catalog";
        }

        public async Task<string> CreateItemAsync(CatalogItemModel model)
        {
            if (model is null)
                throw new Exception("Cannot create an empty model.");

            var createUri = $"{catalogUri}/items/";
            var content = JsonSerializer.Serialize(model);
            var itemContent = new StringContent(content,System.Text.Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync(createUri, itemContent);
            if(response.Headers.Location is not null)
                return response.Headers.Location.ToString().Split("/").Last();

            return "";
        }

        public async Task DeleteItemAsync(string guid)
        {
            var deleteUri = $"{catalogUri}/bc/{guid}";
            var response = await _httpClient.DeleteAsync(deleteUri);
            return;
        }

        public async Task<CatalogItemModel?> GetItemAsync(string guid)
        {
            var getItemUri = $"{catalogUri}/items/bc/{guid}";
            var response = await _httpClient.GetStringAsync(getItemUri);
            
            return JsonSerializer.Deserialize<CatalogItemModel>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task UpdateItemAsync(CatalogItemModel model)
        {
            var updateUri = $"{catalogUri}/items/bc";
            var content = JsonSerializer.Serialize(model);
            var jsonContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(updateUri, jsonContent);
            return;
        }

    }
}
