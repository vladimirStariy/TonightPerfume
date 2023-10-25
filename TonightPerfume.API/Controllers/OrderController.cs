using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Viewmodels.OrderVM;
using TonightPerfume.Service.Services.OrderServ;
using TonightPerfume.Service.Services.ProductServ;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [AllowAnonymous]
        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder(OrderRequestDto model)
        {
            var response = await _orderService.CreateOrderUnauthorized(model);
            return Ok(response);
        }
    }
}
