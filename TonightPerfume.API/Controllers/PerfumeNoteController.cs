using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.ProductServ.Implementations;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class PerfumeNoteController : ControllerBase
    {
        private readonly IPerfumeNoteService _perfumeNoteService;

        public PerfumeNoteController(IPerfumeNoteService perfumeNoteService)
        {
            _perfumeNoteService = perfumeNoteService;
        }

        [AllowAnonymous]
        [HttpGet("notes")]
        public async Task<List<PerfumeNote>> Get()
        {
            var response = await _perfumeNoteService.Get();
            return response.Result;
        }

        [AllowAnonymous]
        [HttpGet("sorted-notes")]
        public async Task<List<PerfumeNote>> GetSortedNotes()
        {
            var response = await _perfumeNoteService.GetSortedNotes();
            return response.Result;
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
