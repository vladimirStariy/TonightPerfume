using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.ProductVM;
using TonightPerfume.Service.Services.ProductServ;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpPost("create-product")]
        public async Task<ProductAddDto> Create(ProductAddDto model)
        {
            var response = await _productService.Create(model);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("product-cards")]
        public async Task<ICollection<ProductCardDto>> Get()
        {
            var response = await _productService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("product")]
        public async Task<ProductDto> GetById(uint id)
        {
            var response = await _productService.GetById(id);
            return response.Result;
        }
    }
}
