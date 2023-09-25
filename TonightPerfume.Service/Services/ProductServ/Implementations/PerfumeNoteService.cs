using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.Service.Services.ProductServ.Implementations
{
    public class PerfumeNoteService : IPerfumeNoteService
    {
        private readonly IRepository<PerfumeNote> _perfumeNoteRepository;

        public PerfumeNoteService(IRepository<PerfumeNote> perfumeNoteRepository)
        {
            _perfumeNoteRepository = perfumeNoteRepository;
        }

        public async Task<IBaseResponce<PerfumeNote>> Create(PerfumeNote model)
        {
            try
            {
                await _perfumeNoteRepository.Create(model);
                return new Response<PerfumeNote>()
                {
                    Result = model,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<PerfumeNote>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
