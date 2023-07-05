using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models.User;
using TonightPerfume.Domain.Viewmodels.UserVM;
using TonightPerfume.Service.Services.UserServ;

namespace TonightPerfume.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController (IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("user")]
        public async Task<BaseUser> GetUser(/*[FromRoute]*/ uint id)
        {
            var response = await _userService.GetById(id);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("users")]
        public async Task<List<BaseUser>> GetUsers()
        {
            var response = await _userService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<BaseUser> Register(RegisterDto model)
        {
            var response = await _userService.Register(model);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var token = await _userService.Login(model);
            return Ok(token.Result);
        }
    }
}
