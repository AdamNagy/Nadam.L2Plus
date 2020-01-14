using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Models;
using Microsoft.AspNetCore.Authorization;

namespace GraduateNotes.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LoginRequestModel userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("User {Name} logged out at {Time}.",
                User.Identity.Name, DateTime.UtcNow);

            #region snippet1
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            return Ok("Sign out successfull");
        }

        [AllowAnonymous]
        [HttpPost]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequestModel requestModel)
        {
            var user = new BasicIdentity()
            {
                Email = requestModel.Email,
                Password = requestModel.Password
            };

            try
            {
                _userService.Register(user, requestModel.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}