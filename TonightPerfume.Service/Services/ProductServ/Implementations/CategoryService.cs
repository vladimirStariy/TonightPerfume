using TonightPerfume.Data.Repository.BaseRepository;
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
    }
}
