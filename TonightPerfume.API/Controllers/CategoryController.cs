using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("categories")]
        public async Task<List<Category>> Get()
        {
            var response = await _categoryService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("create-category")]
        public async Task<Category> Create(Category model)
        {
            var response = await _categoryService.Create(model);
            return response.Result;
        }
    }
}
