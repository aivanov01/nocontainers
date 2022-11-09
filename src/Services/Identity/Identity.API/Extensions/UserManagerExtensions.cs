namespace Identity.API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByGuid(this UserManager<ApplicationUser> um, string guid)
        {
            return await um?.Users?.SingleOrDefaultAsync(x => x.Guid.Equals(guid));
        }
    }
}
