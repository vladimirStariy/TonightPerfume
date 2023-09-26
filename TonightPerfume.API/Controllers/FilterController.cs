using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.Filter;
using TonightPerfume.Service.Services.FilterSrv;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [AllowAnonymous]
        [HttpGet("filter")]
        public async Task<FilterDto> Get(int count)
        {
            var response = await _filterService.Get(count);
            return response.Result;
        }


    }
}
