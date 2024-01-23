using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.ConsultationVM;
using TonightPerfume.Domain.Viewmodels.OrderVM;

namespace TonightPerfume.Service.Services.ConsultServ
{
    public class ConsultationService : IConsultationService
    {
        private readonly IRepository<Consultation> _consultationRepository; 

        public ConsultationService(IRepository<Consultation> consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public async Task<IBaseResponce<string>> CreateConsultationRequest(ConsultationDTO model)
        {
            try
            {
                var consultation = new Consultation()
                {
                    Phone = model.phone,
                    Name = model.name,
                    IsNew = true,
                    IsOver = false,
                    ConsultationDate = DateTime.Now
                };
                
                await _consultationRepository.Create(consultation);

                return new Response<string>()
                {
                    Result = "ok",
                    Description = "Консультация запрошена",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

    }
}
