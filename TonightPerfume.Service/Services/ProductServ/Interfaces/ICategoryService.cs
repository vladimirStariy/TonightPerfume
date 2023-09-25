using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;

namespace TonightPerfume.Service.Services.ProductServ.Interfaces
{
    public interface ICategoryService
    {
        Task<IBaseResponce<Category>> Create(Category model);
        Task<IBaseResponce<List<Category>>> Get();
    }
}
