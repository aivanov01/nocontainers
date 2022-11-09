using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Text.Json;

namespace BuisnessCentral.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _settings;
        private readonly string _identityUrl;
        public UserService(HttpClient httpClinet, IOptions<AppSettings> settings)
        {
            _httpClient = httpClinet;
            _settings = settings;
            _identityUrl = $"{_settings.Value.IdentityUrl}/api/accountapi";
        }
        public async Task<ApplicationUser?> GetApplicationUserAsync(string guid)
        {
            var getUri = $"{_identityUrl}/users/{guid}";
            var response = await _httpClient.GetStringAsync(getUri);

            return JsonSerializer.Deserialize<ApplicationUser>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task CreateUserAsync(ApplicationUser user)
        {
            if (user is null)
                throw new Exception("Cannot create an empty object");

            var createUri = $"{_identityUrl}/users/create";
            var content = JsonSerializer.Serialize(user);
            var userContent = new StringContent(content, Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PostAsync(createUri, userContent);
        }

        public async Task DeleteUserAsync(string guid)
        {
            var deleteUri = $"{_identityUrl}/users/delete/{guid}";
            await _httpClient.DeleteAsync(deleteUri);
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            var updateUri = $"{_identityUrl}/users/update";
            var content = JsonSerializer.Serialize(user);
            var userContent = new StringContent(content, Encoding.UTF8, "application/json");
            var reponse = await _httpClient.PostAsync(updateUri, userContent);
        }
    }
}
