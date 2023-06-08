using AutoMapper;
using Microsoft.Extensions.Logging;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models.Product;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.ProductVM;

namespace TonightPerfume.Service.Services.ProductServ
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public ProductService(IMapper mapper, IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public IBaseResponce<List<ProductCardViewModel>> GetProductCards()
        {
            try
            {
                var products = _productRepository.Get().ToList();
                if (!products.Any())
                {
                    return new Response<List<ProductCardViewModel>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }
                var productCards = _mapper.Map<List<Product>, List<ProductCardViewModel>>(products);
                return new Response<List<ProductCardViewModel>>()
                {
                    Result = productCards,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<ProductCardViewModel>>()
                {
                    Description = $"[GetProducts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
