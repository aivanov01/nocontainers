using BuisnessCentral.Models;

namespace BuisnessCentral.Services
{
    public partial interface IItemService
    {
        Task<string> CreateItemAsync(CatalogItemModel model);
        Task UpdateItemAsync(CatalogItemModel model);
        Task DeleteItemAsync(string guid);
        Task<CatalogItemModel?> GetItemAsync(string guid);

    }
}
