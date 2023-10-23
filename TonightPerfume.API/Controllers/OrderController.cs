using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Viewmodels.OrderVM;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder(OrderRequestDto model)
        {
            throw new NotImplementedException();
        }
    }
}
