using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Utils;
using TonightPerfume.Domain.Viewmodels.ProductVM;
using TonightPerfume.Service.Services.DiscountServ;
using TonightPerfume.Service.Services.ProductServ;
using TonightPerfume.Service.Services.ProductServ.Interfaces;
using TonightPerfume.Service.Services.ProfileServ;
using TonightPerfume.Service.Services.UserServ;

namespace TonightPerfume.API.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPerfumeNoteService _perfumeNoteService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IAromaGroupService _aromaGroupService;
        private readonly IDiscountService _discountService;
        private readonly ProfileService _profileService;
        private readonly IUserService _userService;

        public AdminController(
            IProductService productService,
            IPerfumeNoteService perfumeNoteService,
            IBrandService brandService,
            ICategoryService categoryService,
            IAromaGroupService aromaGroupService,
            IDiscountService discountService,
            ProfileService profileService,
            IUserService userService)
        {
            _productService = productService;
            _perfumeNoteService = perfumeNoteService;
            _brandService = brandService;
            _categoryService = categoryService;
            _aromaGroupService = aromaGroupService;
            _discountService = discountService;
            _profileService = profileService;
            _userService = userService;
        }

        // Products

        [HttpPost("create-product")]
        public async Task<ProductAddDto> Create([FromForm] IFormFile file, [FromForm] ProductAddDto model)
        {
            var prices = HttpContext.Request.Form.ToList().Where(x =>
                x.Key.StartsWith("Prices")).Select(x => x.Value).ToList();

            List<PricesDto> des_prices = new List<PricesDto>();
            foreach (var price in prices)
            {
                var des_price = JsonDeserializer.DeserializePricesJson(price);
                des_prices.Add(des_price);
            }
            model.Prices = des_prices;
            var response = await _productService.Create(file, model);
            return response.Result;
        }

        [HttpPut("edit-product")]
        public async Task<ICollection<Discount>> EditProduct()
        {
            var response = await _discountService.Get();
            return response.Result;
        }

        // Brands

        [HttpPost("add-brand")]
        public async Task<ICollection<Discount>> AddBrand()
        {
            var response = await _discountService.Get();
            return response.Result;
        }

        [HttpPut("edit-brand")]
        public async Task<ICollection<Discount>> EditBrand()
        {
            var response = await _discountService.Get();
            return response.Result;
        }

        // Notes

        [HttpPost("add-note")]
        public async Task<ICollection<Discount>> AddNote()
        {
            var response = await _discountService.Get();
            return response.Result;
        }

        [HttpPut("edit-note")]
        public async Task<ICollection<Discount>> EditNote()
        {
            var response = await _discountService.Get();
            return response.Result;
        }

        [HttpPut("accept-order")]
        public async Task<ICollection<Discount>> AcceptOrder()
        {
            var response = await _discountService.Get();
            return response.Result;
        }
    }
}
