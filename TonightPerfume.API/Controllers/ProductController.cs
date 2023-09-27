using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.Filter;
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
        [HttpGet("product-cards-all")]
        public async Task<ICollection<ProductCardDto>> Get()
        {
            var response = await _productService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("product-cards")]
        public async Task<ICollection<ProductCardDto>> GetWithPagination(int page)
        {
            var response = await _productService.GetProductsWithPagination(page);
 
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pages-Count, X-Pages-HasNext, X-Pages-HasPrevious, X-Pages-CurrentPage");

            Response.Headers.Add("X-Pages-Count", JsonConvert.SerializeObject(response.Result.Count));
            Response.Headers.Add("X-Pages-HasNext", JsonConvert.SerializeObject(response.Result.HasNext));
            Response.Headers.Add("X-Pages-HasPrevious", JsonConvert.SerializeObject(response.Result.HasPrevious));
            Response.Headers.Add("X-Pages-CurrentPage", JsonConvert.SerializeObject(response.Result.CurrentPage));
            Response.Headers.Add("X-Pages-TotalPages", JsonConvert.SerializeObject(response.Result.TotalPages));

            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("product")]
        public async Task<ProductDto> GetById(uint id)
        {
            var response = await _productService.GetById(id);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("filter")]
        public async Task<FilterDto> Get(int count)
        {
            var response = await _productService.GetFilter(count);
            return response.Result;
        }
    }
}
