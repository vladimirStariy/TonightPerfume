using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.ProductVM;

namespace TonightPerfume.Service.Services.ProductServ
{
    public interface IProductService
    {
        //Task<IBaseResponce<Product>> Create(OrderViewModel model);
        IBaseResponce<List<ProductCardViewModel>> GetProductCards();
    }
}
