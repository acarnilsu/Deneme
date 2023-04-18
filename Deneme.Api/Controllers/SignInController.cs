using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public SignInController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUser user)
        {


            AppUser newUser = new();
            newUser.UserName = user.UserName;


            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
            }


            return BadRequest();
        }

    }
       
}
