using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.UserVM;
using TonightPerfume.Service.Services.AccountServ;
using TonightPerfume.Service.Services.UserServ;
using static System.Net.WebRequestMethods;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController (IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<string> Register(RegisterDto model)
        {
            var response = await _accountService.RegisterBySms(model.Phone);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("loginByNum")]
        public async Task<string> LoginByNumber(string number)
        {
            var response = await _accountService.RegisterBySms(number);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginByNumDto model)
        {
            model.DeviceData = Request.Headers.UserAgent.ToString();
            var response = await _accountService.Login(model);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                HttpContext.Response.Cookies.Append("refreshToken", response.Result["refreshToken"], new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Lax, Expires = DateTime.Now.AddDays(30) });
                return Ok(response.Result);
            }
            else
            {
                return BadRequest(StatusCodes.Status404NotFound);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            await _accountService.Logout(token);
            HttpContext.Response.Cookies.Append("refreshToken", "", new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Lax, Expires = DateTime.Now.AddDays(-1d) });
            return Ok("cookie deleted");
        }

        [AllowAnonymous]
        [HttpGet("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            if(token != null)
            {
                var response = await _accountService.RefreshToken(token);
                HttpContext.Response.Cookies.Append("refreshToken", response.Result["refreshToken"], new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Lax, Expires = DateTime.Now.AddDays(30) });
                return Ok(response.Result);
            }
            return Ok();
        }
    }
}
