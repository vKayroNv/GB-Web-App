using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.Interfaces;
using Timesheets.Core.Responses;

namespace Timesheets.API.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-profile")]
        public async Task<IActionResult> CreateProfile([FromQuery] string username, string password, CancellationToken cts)
        {
            var result = await _userService.CreateProfile(username, password, cts);

            if (result)
                return Ok(new { message = $"Profile \"{username}\" has been created" });
            else
                return BadRequest(new { message = $"Profile \"{username}\" already exists" });
        }

        [HttpPost("delete-profile")]
        public async Task<IActionResult> DeleteProfile([FromQuery] string username, string password, CancellationToken cts)
        {
            var result = await _userService.DeleteProfile(username, password, cts);

            if (result)
                return Ok(new { message = $"Profile \"{username}\" has been deleted" });
            else
                return BadRequest(new { message = $"Username or password is incorrect" });
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string username, string password, CancellationToken cts)
        {
            var token = await _userService.Authenticate(username, password, cts);
            if (token is null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }

        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(CancellationToken cts)
        {
            var result = await _userService.RefreshToken(Request.Cookies["refreshToken"], cts);
            SetTokenCookie(result);
            return Ok(result);
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
