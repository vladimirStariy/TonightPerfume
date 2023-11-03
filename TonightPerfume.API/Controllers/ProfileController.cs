using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Viewmodels.ProfileVM;
using TonightPerfume.Service.Services.ProductServ;
using TonightPerfume.Service.Services.ProfileServ;

namespace TonightPerfume.API.Controllers
{
    [Authorize]
    [Route("")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> Orders()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _profileService.GetOrders(token);
            return Ok(response.Result);
        }

        [HttpGet("profile-data")]
        public async Task<IActionResult> GetProfileData()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _profileService.GetProfileData(token);
            return Ok(response.Result);
        }

        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _profileService.UpdateProfile(dto, token);
            return Ok(response.Result);
        }

        [HttpPost("create-adress")]
        public async Task<IActionResult> CreateAdress(ProfileAdressDto model)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _profileService.AddAdress(model, token);
            return Ok(response.Result);
        }

        [HttpDelete("delete-adress")]
        public async Task<IActionResult> DeleteAdress(uint id)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _profileService.DeleteAdress(id, token);
            return Ok(response.StatusCode);
        }

        [HttpGet("promocodes")]
        public async Task<IActionResult> Promocodes()
        {
            return Ok(new ProfileTestDto() { response = "Success" });
        }
    }
}
