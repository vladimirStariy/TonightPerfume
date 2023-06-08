using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Service.Services.ProductServ;

namespace TonightPerfume.Client.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Products()
        {
            var response = _productService.GetProductCards();
            return View(response.Result);
        }
    }
}
