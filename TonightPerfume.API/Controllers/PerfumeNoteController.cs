using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerfumeNoteController : ControllerBase
    {
        private readonly IPerfumeNoteService _perfumeNoteService;

        public PerfumeNoteController(IPerfumeNoteService perfumeNoteService)
        {
            _perfumeNoteService = perfumeNoteService;
        }

        [AllowAnonymous]
        [HttpPost("create-note")]
        public async Task<PerfumeNote> Create(PerfumeNote model)
        {
            var response = await _perfumeNoteService.Create(model);
            return response.Result;
        }
    }
}
