using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.ProductVM;
using TonightPerfume.Service.Services.ProductServ;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.API.Controllers
{
    [Route("")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IPerfumeNoteService _notesService;

        public NotesController(IPerfumeNoteService notesService)
        {
            _notesService = notesService;
        }

        [AllowAnonymous]
        [HttpGet("get-table-notes")]
        public async Task<ICollection<PerfumeNote>> Get()
        {
            var response = await _notesService.Get();
            return response.Result;
        }
    }
}
