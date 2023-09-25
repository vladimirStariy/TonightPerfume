using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class AromaGroupController : ControllerBase
    {
        private readonly IAromaGroupService _aromaGroupService;

        public AromaGroupController(IAromaGroupService aromaGroupService)
        {
            _aromaGroupService = aromaGroupService;
        }

        [AllowAnonymous]
        [HttpGet("aroma-groups")]
        public async Task<List<AromaGroup>> Get()
        {
            var response = await _aromaGroupService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("filter-aroma-groups")]
        public async Task<List<AromaGroup>> GetSomeGroups(int count)
        {
            var response = await _aromaGroupService.GetSomeGroups(count);
            return response.Result;
        }

        [AllowAnonymous]
        [HttpPost("create-aroma-group")]
        public async Task<AromaGroup> Create(AromaGroup model)
        {
            var response = await _aromaGroupService.Create(model);
            return response.Result;
        }
    }
}
