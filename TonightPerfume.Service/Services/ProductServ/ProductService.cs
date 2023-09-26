using AutoMapper;
using Microsoft.Extensions.Logging;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.ProductVM;

namespace TonightPerfume.Service.Services.ProductServ
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<PerfumeNote> _perfumeNotesRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<Price> _priceRepository;

        public ProductService(
            IRepository<Product> productRepository,
            IRepository<PerfumeNote> perfumeNotesRepository,
            IRepository<Discount> discountRepository,
            IRepository<Price> priceRepository
        )
        {
            _productRepository = productRepository;
            _perfumeNotesRepository = perfumeNotesRepository;
            _discountRepository = discountRepository;
            _priceRepository = priceRepository;
        }

        public async Task<IBaseResponce<ProductAddDto>> Create(ProductAddDto model)
        {
            try
            {
                var _notes = new List<PerfumeNote>();
                var _aromaGroups = new List<AromaGroup>();

                foreach (var item in model.PerfumeNotes)
                {
                    _notes.Add(await _perfumeNotesRepository.GetById(item));
                }

                var newProduct = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Brand_ID = model.Brand_ID,
                    Category_ID = model.Category_ID,
                    Year = model.Year,
                    Country = model.Country,
                    PerfumeNotes = _notes
                };

                await _productRepository.Create(newProduct);

                foreach (var item in model.Prices)
                {
                    Price price = new Price()
                    {
                        Product_ID = newProduct.Product_ID,
                        Volume_ID = item.Volume_ID,
                        Value = item.Value
                    };

                    await _priceRepository.Create(price);
                }

                return new Response<ProductAddDto>()
                {
                    Result = model,
                    Description = "Продукт добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductAddDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<ProductCardDto>>> Get()
        {
            try
            {
                var products = _productRepository.Get();
                var productCardDtos = new List<ProductCardDto>();
                var prices = _priceRepository.Get();

                if (!products.Any())
                {
                    return new Response<List<ProductCardDto>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                var discounts = _discountRepository.Get().ToList();

                foreach (var item in products)
                {
                    var productDto = new ProductCardDto()
                    {
                        Id = item.Product_ID,
                        Name = item.Name,
                        Brand = item.Brand.Name,
                        Price = prices.Where(x => x.Product_ID == item.Product_ID).Min(x => x.Value)
                    };

                    if(!discounts.Any())
                    {
                        productDto.Discount = 0;
                    }
                    else
                    {
                        productDto.Discount = discounts.Where(x => x.Product_ID == item.Product_ID).Select(x => x.Value).FirstOrDefault();
                    }

                    productCardDtos.Add(productDto);
                }

                return new Response<List<ProductCardDto>>()
                {
                    Result = productCardDtos,
                    Description = "Продукт добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<ProductCardDto>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<ProductDto>> GetById(uint id)
        {
            try
            {
                var product = await _productRepository.GetById(id);
                var prices = _priceRepository.Get().Where(x => x.Product_ID == id);

                var productDto = new ProductDto()
                {
                    Id = product.Product_ID,
                    Name = product.Name,
                    Description = product.Description,
                    Prices = prices.ToList(),
                    Brand = product.Brand,
                    Category = product.Category,
                    PerfumeNotes = product.PerfumeNotes
                };

                return new Response<ProductDto>()
                {
                    Result = productDto,
                    Description = "Объект добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

    }
}
