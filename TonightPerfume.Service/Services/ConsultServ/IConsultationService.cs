using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.ConsultationVM;

namespace TonightPerfume.Service.Services.ConsultServ
{
    public interface IConsultationService
    {
        Task<IBaseResponce<string>> CreateConsultationRequest(ConsultationDTO model);
    }
}
