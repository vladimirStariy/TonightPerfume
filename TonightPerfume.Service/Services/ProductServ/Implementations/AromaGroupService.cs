using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.Service.Services.ProductServ.Implementations
{
    public class AromaGroupService : IAromaGroupService
    {
        private readonly IRepository<AromaGroup> _aromaGroupRepository;

        public AromaGroupService(IRepository<AromaGroup> aromaGroupRepository)
        {
            _aromaGroupRepository = aromaGroupRepository;
        }

        public async Task<IBaseResponce<AromaGroup>> Create(AromaGroup model)
        {
            try
            {
                await _aromaGroupRepository.Create(model);
                return new Response<AromaGroup>()
                {
                    Result = model,
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<AromaGroup>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<AromaGroup>>> Get()
        {
            try
            {
                var aromaGroups = _aromaGroupRepository.Get();

                if (!aromaGroups.Any())
                {
                    return new Response<List<AromaGroup>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<AromaGroup>>()
                {
                    Result = aromaGroups.ToList(),
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<AromaGroup>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<AromaGroup>>> GetSortedGroups()
        {
            try
            {
                var groups = _aromaGroupRepository.Get().ToList().OrderBy(x => x.AromaGroup_Name);

                if (!groups.Any())
                {
                    return new Response<List<AromaGroup>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<AromaGroup>>()
                {
                    Result = groups.ToList(),
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<AromaGroup>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<AromaGroup>>> GetSomeGroups(int count)
        {
            try
            {
                var aromaGroups = _aromaGroupRepository.Get().ToList().OrderBy(x => x.AromaGroup_Name).Take(count);

                if (!aromaGroups.Any())
                {
                    return new Response<List<AromaGroup>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<AromaGroup>>()
                {
                    Result = aromaGroups.ToList(),
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<AromaGroup>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
