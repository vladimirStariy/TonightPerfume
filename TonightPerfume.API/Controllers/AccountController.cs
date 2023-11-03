using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.UserVM;
using TonightPerfume.Service.Services.AccountServ;
using TonightPerfume.Service.Services.UserServ;

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
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var response = await _accountService.RegisterBySms(model.Phone);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
                return Ok(response.Result);
            else
                return BadRequest(StatusCodes.Status400BadRequest);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginByNumDto model)
        {
            model.DeviceData = Request.Headers.UserAgent.ToString();
            var response = await _accountService.Login(model);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                HttpContext.Response.Cookies.Append("refreshToken", response.Result.tokenPairs["refreshToken"], 
                    new CookieOptions() 
                    { 
                        HttpOnly = true, 
                        SameSite = SameSiteMode.None, 
                        Secure = true, 
                        Expires = DateTime.Now.AddDays(30) 
                    });
                HttpContext.Response.Cookies.Append("is_auth", "true",
                    new CookieOptions()
                    {
                        HttpOnly = false,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Expires = DateTime.Now.AddDays(30)
                    });
                return Ok(new LoginResponse() { access = response.Result.tokenPairs["accessToken"] });
            }
            else
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            await _accountService.Logout(token);
            HttpContext.Response.Cookies.Append("refreshToken", "", 
                new CookieOptions() 
                { 
                    HttpOnly = true, 
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(-1d) 
                });
            HttpContext.Response.Cookies.Append("is_auth", "",
                    new CookieOptions()
                    {
                        HttpOnly = false,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Expires = DateTime.Now.AddDays(-1d)
                    });
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
                
                HttpContext.Response.Cookies.Append("refreshToken", response.Result["refreshToken"],
                    new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Expires = DateTime.Now.AddDays(30)
                    });
                return Ok(new LoginResponse() { access = response.Result["accessToken"] });
            }
            return Ok();
        }
    }
}
