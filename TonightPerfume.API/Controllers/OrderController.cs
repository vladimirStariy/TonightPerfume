using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Enum;
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
        [HttpPost("create-order-unauthorized")]
        public async Task<IActionResult> CreateOrderUnauthorized(OrderRequestDto model)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];

            if(token == null)
            {
                var response = await _orderService.CreateOrderUnauthorized(model);
                return Ok(response);
            } 
            else
            {
                var response = await _orderService.CreateOrderAuthorized(model, token);
                return Ok(response);
            }

        }

        [Authorize]
        [HttpPost("create-order-authorized")]
        public async Task<IActionResult> CreateOrderAuthorized(OrderRequestDto model)
        {
            var response = await _orderService.CreateOrderUnauthorized(model);
            return Ok(response);
        }

        [HttpPost("get-promocode-data")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPromocodeData(PromocodeDto model)
        {
            var response = await _orderService.GetPromocodeData(model.promocode);
            if(response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
                return NotFound("Invalid promocode");
            }
            return Ok(response.Result);
        }
    }
}
