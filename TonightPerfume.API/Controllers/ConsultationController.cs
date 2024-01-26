using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TonightPerfume.Domain.Viewmodels.ConsultationVM;
using TonightPerfume.Service.Services.AccountServ;
using TonightPerfume.Service.Services.ConsultServ;

namespace TonightPerfume.API.Controllers
{
    [Route("consultation")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [AllowAnonymous]
        [HttpPost("request-consultation")]
        public async Task<IActionResult> RequestConsultation(ConsultationDTO model)
        {
            var response = await _consultationService.CreateConsultationRequest(model);
            if(response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
                return BadRequest(response.Result);
            }
            return Ok(JsonSerializer.Serialize(response.Result));
        }
    }
}
