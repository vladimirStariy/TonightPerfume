using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.ProductVM;

namespace TonightPerfume.Service.Services.ProductServ
{
    public interface IProductService
    {
        Task<IBaseResponce<ProductAddDto>> Create(ProductAddDto model);
        Task<IBaseResponce<List<ProductCardDto>>> Get();
        Task<IBaseResponce<ProductDto>> GetById(uint id);
    }
}
