using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.DiscountDto;

namespace TonightPerfume.Service.Services.DiscountServ
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepository<Discount> _discountRepository;

        public DiscountService(IRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<IBaseResponce<BrandDiscountDto>> CreateBrandDiscount(BrandDiscountDto model)
        {
            try
            {
                var discount = new Discount()
                {
                    Discount_Type = "brand_discount",
                    Brand_ID = model.Brand_ID,
                    Value = model.Value
                };

                await _discountRepository.Create(discount);

                return new Response<BrandDiscountDto>()
                {
                    Result = model,
                    Description = "Продукт добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<BrandDiscountDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<ProductDiscountDto>> CreateProductDiscount(ProductDiscountDto model)
        {
            try
            {
                var discount = new Discount()
                {
                    Discount_Type = "single_product",
                    Product_ID = model.Product_ID,
                    Value = model.Value
                };

                await _discountRepository.Create(discount);

                return new Response<ProductDiscountDto>()
                {
                    Result = model,
                    Description = "Продукт добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductDiscountDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<Discount>>> Get()
        {
            try
            {
                var discounts = _discountRepository.Get();

                if (!discounts.Any())
                {
                    return new Response<List<Discount>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<List<Discount>>()
                {
                    Result = discounts.ToList(),
                    Description = "Продукт добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<Discount>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
