using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.DiscountDto;

namespace TonightPerfume.Service.Services.DiscountServ
{
    public interface IDiscountService
    {
        Task<IBaseResponce<ProductDiscountDto>> CreateProductDiscount(ProductDiscountDto model);
        Task<IBaseResponce<BrandDiscountDto>> CreateBrandDiscount(BrandDiscountDto model);
        Task<IBaseResponce<List<Discount>>> Get();
    }
}
