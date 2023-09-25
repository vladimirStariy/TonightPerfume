using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.DiscountDto;
using TonightPerfume.Service.Services.DiscountServ;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [AllowAnonymous]
        [HttpGet("get-discounts")]
        public async Task<ICollection<Discount>> GetDiscounts()
        {
            var response = await _discountService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("create-product-discount")]
        public async Task<ProductDiscountDto> CreateProductDiscount(ProductDiscountDto model)
        {
            var response = await _discountService.CreateProductDiscount(model);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("create-brand-discount")]
        public async Task<BrandDiscountDto> CreateBrandDiscount(BrandDiscountDto model)
        {
            var response = await _discountService.CreateBrandDiscount(model);
            return response.Result;
        }
    }
}
