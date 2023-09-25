using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.Filter;

namespace TonightPerfume.Service.Services.FilterSrv
{
    public class FilterService : IFilterService
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<AromaGroup> _aromaGroupRepository;

        public FilterService(
            IRepository<Brand> brandRepository,
            IRepository<Category> categoryRepository,
            IRepository<AromaGroup> aromaGroupRepository
            )
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _aromaGroupRepository = aromaGroupRepository;
        }

        public async Task<IBaseResponce<FilterDto>> Get(int count)
        {
            try
            {
                var aromaGroups = _aromaGroupRepository.Get().ToList().OrderBy(x => x.AromaGroup_Name).Take(count);
                var brands = _brandRepository.Get().ToList().OrderBy(x => x.Name).Take(count);

                FilterDto filterDto = new FilterDto()
                {
                    AromaGroups = aromaGroups.ToList(),
                    Brands = brands.ToList()
                };

                return new Response<FilterDto>()
                {
                    Result = filterDto,
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex) 
            {
                return new Response<FilterDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
