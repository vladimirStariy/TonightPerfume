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
        private readonly IRepository<PerfumeNote> _perfumeNoteRepository;
        private readonly IRepository<Product> _productRepository;

        public FilterService(
            IRepository<Brand> brandRepository,
            IRepository<Category> categoryRepository,
            IRepository<AromaGroup> aromaGroupRepository,
            IRepository<PerfumeNote> perfumeNoteRepository,
            IRepository<Product> productRepository
            )
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _aromaGroupRepository = aromaGroupRepository;
            _perfumeNoteRepository = perfumeNoteRepository;
            _productRepository = productRepository;
        }

        public async Task<IBaseResponce<FilterDto>> Get(int count)
        {
            try
            {
                var aromaGroups = _aromaGroupRepository.Get().ToList().OrderBy(x => x.AromaGroup_Name).Take(count);
                var brands = _brandRepository.Get().ToList().OrderBy(x => x.Name).Take(count);
                var categories = _categoryRepository.Get();
                var notes = _perfumeNoteRepository.Get().ToList().OrderBy(x => x.Name).Take(count);
                var countries = _productRepository.Get().ToList().OrderBy(x => x.Country).Select(x => x.Country).Take(count);

                FilterDto filterDto = new FilterDto()
                {
                    AromaGroups = aromaGroups.ToList(),
                    Brands = brands.ToList(),
                    Categories = categories.ToList(),
                    PerfumeNotes = notes.ToList(),
                    Countries = countries.ToList(),
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
