using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
