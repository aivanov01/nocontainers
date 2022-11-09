namespace BuisnessCentral.Services
{
    public interface IUserService
    {
        Task<ApplicationUser?> GetApplicationUserAsync(string guid);
        Task CreateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(string guid);
        Task UpdateUserAsync(ApplicationUser user);
    }
}
