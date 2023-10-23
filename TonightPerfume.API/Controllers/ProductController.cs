using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Security;
using TonightPerfume.Domain.Viewmodels.Filter;
using TonightPerfume.Domain.Viewmodels.ProductVM;
using TonightPerfume.Domain.Viewmodels.ProfileVM;
using TonightPerfume.Service.Services.ProductServ;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    [Authorize]
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
 
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pages-Count, X-Pages-HasNext, X-Pages-HasPrevious, X-Pages-CurrentPage, X-Pages-TotalPages");

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

        [AllowAnonymous]
        [HttpPost("filter-requ")]
        public async Task<ICollection<ProductCardDto>> GetFilteredData(FilterRequestDto model)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _productService.GetFilteredProductsWithPagination(model, token);

            if(response.Result != null)
            {
                Response.Headers.Add("Access-Control-Expose-Headers", "X-Pages-Count, X-Pages-HasNext, X-Pages-HasPrevious, X-Pages-CurrentPage, X-Pages-TotalPages");

                Response.Headers.Add("X-Pages-Count", JsonConvert.SerializeObject(response.Result.Count));
                Response.Headers.Add("X-Pages-HasNext", JsonConvert.SerializeObject(response.Result.HasNext));
                Response.Headers.Add("X-Pages-HasPrevious", JsonConvert.SerializeObject(response.Result.HasPrevious));
                Response.Headers.Add("X-Pages-CurrentPage", JsonConvert.SerializeObject(response.Result.CurrentPage));
                Response.Headers.Add("X-Pages-TotalPages", JsonConvert.SerializeObject(response.Result.TotalPages));
            }

            return response.Result;
        }

        [Authorize]
        [HttpGet("favorites")]
        public async Task<ICollection<ProductCardDto>> GetFavorites(int page)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            FavoriteRequestDto request = new FavoriteRequestDto() { page = page, token = token };
            var response = await _productService.GetFavorites(request);
            if(response.Result != null)
            {
                Response.Headers.Add("Access-Control-Expose-Headers", "X-Pages-Count, X-Pages-HasNext, X-Pages-HasPrevious, X-Pages-CurrentPage, X-Pages-TotalPages");
                Response.Headers.Add("X-Pages-Count", JsonConvert.SerializeObject(response.Result.Count));
                Response.Headers.Add("X-Pages-HasNext", JsonConvert.SerializeObject(response.Result.HasNext));
                Response.Headers.Add("X-Pages-HasPrevious", JsonConvert.SerializeObject(response.Result.HasPrevious));
                Response.Headers.Add("X-Pages-CurrentPage", JsonConvert.SerializeObject(response.Result.CurrentPage));
                Response.Headers.Add("X-Pages-TotalPages", JsonConvert.SerializeObject(response.Result.TotalPages));
            }
            return response.Result;
        }

        [Authorize]
        [HttpPost("add-favorite")]
        public async Task<IActionResult> AddFavorite(AddToFavoriteRequestDto model)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _productService.AddFavorite(model.id, token);
            return Ok(response.Result);
        }

        [Authorize]
        [HttpDelete("remove-favorite")]
        public async Task<IActionResult> RemoveFavorite(uint id)
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var response = await _productService.RemoveFavorite(id, token);
            return Ok(response.Result);
        }

    }
}
