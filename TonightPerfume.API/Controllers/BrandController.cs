using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [AllowAnonymous]
        [HttpGet("brands")]
        public async Task<List<Brand>> Get()
        {
            var response = await _brandService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("filter-brands")]
        public async Task<List<Brand>> GetSomeBrands(int count)
        {
            var response = await _brandService.GetSomeBrands(count);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("create-brand")]
        public async Task<Brand> Create(Brand model)
        {
            var response = await _brandService.Create(model);
            return response.Result;
        }


    }
}
