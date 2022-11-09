using BuisnessCentral.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuisnessCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("{guid}")]
        [HttpGet]
        public async Task<ActionResult<ApplicationUser>> GetUserAsync(string guid)
        {
            try
            {
                var user = await _userService.GetApplicationUserAsync(guid);
                return Ok(user);
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(ApplicationUser user)
        {
            try
            {
                await _userService.CreateUserAsync(user);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("{guid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string guid)
        {
            await _userService.DeleteUserAsync(guid);
            return Ok();
        }

        [Route("update")]
        [HttpPost]
        public async Task UpdateUser(ApplicationUser user)
        {
            await _userService.UpdateUserAsync(user);
        }
    }
}
