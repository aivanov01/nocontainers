using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public AccountApiController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("users/{guid}")]
        [HttpGet]
        public async Task<ActionResult<ApplicationUser>> GetUserByGuid(string guid)
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Guid.Equals(guid));
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [Route("users/create")]
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> CreateUser(ApplicationUser user)
        {
            if (user is null)
                return NotFound("No properties set for user");

            var created = await _userManager.CreateAsync(user);
            if (created is null)
                return NotFound("Something went wrong :(");

            return Ok(user);
        }

        [Route("users/delete/{guid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string guid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Guid.Equals(guid));
            if (user is null)
                return NotFound("No user with this Guid is found");
            await _userManager.DeleteAsync(user);
            return Ok();
        }

        [Route("users/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(ApplicationUser appUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Guid.Equals(appUser.Guid));
            if (user is null)
                return NotFound("User with such guid is not found");
            try
            {
                user.Name = appUser.Name;
                user.LastName = appUser.LastName;
                user.PhoneNumber = appUser.PhoneNumber;
                user.CardHolderName = appUser.CardHolderName;
                user.CardType = appUser.CardType;
                user.City = appUser.City;
                user.Street = appUser.Street;
                user.ZipCode = appUser.ZipCode;
                user.Expiration = appUser.Expiration;
                user.SecurityNumber = appUser.SecurityNumber;
                user.CardNumber = appUser.CardNumber;
                await _userManager.UpdateAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
