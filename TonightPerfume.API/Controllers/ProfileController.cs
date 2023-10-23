using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Viewmodels.ProfileVM;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        [Authorize]
        [HttpGet("orders")]
        public async Task<IActionResult> Orders()
        {
            return Ok(new ProfileTestDto() { response = "Success" });
        }

        [Authorize]
        [HttpGet("promocodes")]
        public async Task<IActionResult> Promocodes()
        {
            return Ok(new ProfileTestDto() { response = "Success" });
        }
    }
}
