using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Service.Services.ProductServ.Interfaces;

namespace TonightPerfume.Service.Services.ProductServ.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IBaseResponce<Category>> Create(Category model)
        {
            try
            {
                await _categoryRepository.Create(model);
                return new Response<Category>()
                {
                    Result = model,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<Category>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<Category>>> Get()
        {
            try
            {
                var categories = _categoryRepository.Get();

                if (!categories.Any())
                {
                    return new Response<List<Category>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<Category>>()
                {
                    Result = categories.ToList(),
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Category>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
