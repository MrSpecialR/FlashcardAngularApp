using System;
using System.Threading.Tasks;
using LanguageLearningPlatform.Services;
using LanguageLearningPlatform.Web.BindingModels;
using Microsoft.AspNetCore.Authorization;

namespace LanguageLearningPlatform.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("users/[action]")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService userService)
        {
            this.usersService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginBindingModel user)
        {
            var token = this.usersService.Login(user.Username, user.Password);
            if (token is null)
            {
                return BadRequest(new { message = "Invalid Credentials!" });
            }
            return Ok(new { token = token, isAdmin = this.usersService.IsAdmin(token), name = user.Username, message = "Login successful!" });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterBindingModel user)
        {
            var token = await this.usersService.Register(user.Username, user.Email, user.Password);
            if (token is null)
            {
                return Conflict(new
                {
                    message = "Username or email is taken!"
                });
            }
            return Ok(new { token = token, name = user.Username, isAdmin = this.usersService.IsAdmin(token), message = "Registration successful!" });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public bool Test()
        {
            return true;
        }
    }
}
