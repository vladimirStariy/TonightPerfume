using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Security;
using TonightPerfume.Domain.Utils;
using TonightPerfume.Domain.Viewmodels.Filter;
using TonightPerfume.Domain.Viewmodels.ProductVM;
using TonightPerfume.Domain.Viewmodels.ProfileVM;

namespace TonightPerfume.Service.Services.ProductServ
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<PerfumeNote> _perfumeNotesRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<Price> _priceRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<AromaGroup> _aromaGroupRepository;
        private readonly IRepository<Favorite> _favoriteRepository;

        public ProductService(
            IRepository<Product> productRepository,
            IRepository<PerfumeNote> perfumeNotesRepository,
            IRepository<Discount> discountRepository,
            IRepository<Price> priceRepository,
            IRepository<Brand> brandRepository,
            IRepository<Category> categoryRepository,
            IRepository<AromaGroup> aromaGroupRepository,
            IRepository<Favorite> favoriteRepository
        )
        {
            _productRepository = productRepository;
            _perfumeNotesRepository = perfumeNotesRepository;
            _discountRepository = discountRepository;
            _priceRepository = priceRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _aromaGroupRepository = aromaGroupRepository;
            _favoriteRepository = favoriteRepository;
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

        public async Task<IBaseResponce<FilterDto>> GetFilter(int count)
        {
            try
            {
                var aromaGroups = _aromaGroupRepository.Get().ToList().OrderBy(x => x.AromaGroup_Name).Take(count);
                var brands = _brandRepository.Get().ToList().OrderBy(x => x.Name).Take(count);
                var categories = _categoryRepository.Get();
                var notes = _perfumeNotesRepository.Get().ToList().OrderBy(x => x.Name).Take(count);
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

        public async Task<IBaseResponce<PagedList<ProductCardDto>>> GetProductsWithPagination(int page)
        {
            try
            {
                var products = _productRepository.Get().ToList();
                var productCardDtos = new List<ProductCardDto>();
                var prices = _priceRepository.Get();

                if (!products.Any())
                {
                    return new Response<PagedList<ProductCardDto>>()
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

                    if (!discounts.Any())
                    {
                        productDto.Discount = 0;
                    }
                    else
                    {
                        productDto.Discount = discounts.Where(x => x.Product_ID == item.Product_ID).Select(x => x.Value).FirstOrDefault();
                    }

                    productCardDtos.Add(productDto);
                }

                var result = PagedList<ProductCardDto>.ToPagedList(productCardDtos, page, 10);

                return new Response<PagedList<ProductCardDto>>()
                {
                    Result = result,
                    Description = "Продукт добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<PagedList<ProductCardDto>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<PagedList<ProductCardDto>>> GetFilteredProductsWithPagination(FilterRequestDto model, string token)
        {
            try
            {
                var perfumeNotes = new List<PerfumeNote>();
                var prices = new List<Price>();

                var products = _productRepository.Get();

                if (model.Brands.Count > 0)
                {
                    products = products.Where(x => model.Brands.Contains((int)x.Brand_ID));
                }
                if (model.Categories.Count > 0)
                {
                    products = products.Where(x => model.Categories.Contains((int)x.Category_ID));
                }
                if (model.PerfumeNotes.Count > 0)
                {
                    products = products.Where(x => x.PerfumeNotes.Any(y => model.PerfumeNotes.Contains((int)y.Note_ID)));
                }
                if (model.AromaGroups.Count > 0)
                {
                    products = products.Where(x => x.AromaGroups.Any(y => model.AromaGroups.Contains((int)y.AromaGroup_ID)));
                }
                if (model.Prices.Length > 0)
                {
                    prices = _priceRepository.Get().Where(x => x.Value >= model.Prices[0] && x.Value <= model.Prices[1]).ToList();
                    products = products.Where(x => prices.Any(y => x.Product_ID == y.Product_ID));
                } 
                else
                {
                    prices =_priceRepository.Get().ToList();
                }

                var filteredProducts = products.ToList();

                if (!filteredProducts.Any())
                {
                    return new Response<PagedList<ProductCardDto>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                var productCardDtos = new List<ProductCardDto>();

                var discounts = _discountRepository.Get().ToList();

                List<uint> favorites = new List<uint>();
                if (token != null)
                {
                    var user_id = JwtTokens.GetPayloadUser(token);
                    favorites = _favoriteRepository.Get().Where(x => x.User_ID == user_id).Select(x => x.Product_ID).ToList();
                }
                foreach (var item in filteredProducts)
                {
                    var _price = 0;
                    try
                    {
                        _price = prices.Where(x => x.Product_ID == item.Product_ID).Min(x => x.Value);
                    }
                    catch
                    {
                        _price = 0;
                    }

                    bool isFavorite = false;
                    if(token != null)
                    {
                        if(favorites.Contains(item.Product_ID))
                            isFavorite = true;
                    }

                    var productDto = new ProductCardDto()
                    {
                        Id = item.Product_ID,
                        Name = item.Name,
                        Brand = item.Brand.Name,
                        Price = _price,
                        isFavorite = isFavorite,
                    };

                    if (!discounts.Any())
                    {
                        productDto.Discount = 0;
                    }
                    else
                    {
                        productDto.Discount = discounts.Where(x => x.Product_ID == item.Product_ID).Select(x => x.Value).FirstOrDefault();
                    }

                    productCardDtos.Add(productDto);
                }

                var result = PagedList<ProductCardDto>.ToPagedList(productCardDtos, model.Page, 10);

                return new Response<PagedList<ProductCardDto>>()
                {
                    Result = result,
                    Description = "Успешно",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<PagedList<ProductCardDto>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<PagedList<ProductCardDto>>> GetFavorites(FavoriteRequestDto model)
        {
            var user_id = JwtTokens.GetPayloadUser(model.token);

            var favorites = _favoriteRepository.Get().Where(x => x.User_ID == user_id).ToList();
            var favoritesProductsIds = favorites.Select(x => x.Product_ID).ToList(); 
            var products = _productRepository.Get().Where(x => favoritesProductsIds.Contains(x.Product_ID)).ToList();
            var productCardDtos = new List<ProductCardDto>();
            var prices = _priceRepository.Get();

            if (!products.Any())
            {
                return new Response<PagedList<ProductCardDto>> ()
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
                    Price = prices.Where(x => x.Product_ID == item.Product_ID).Min(x => x.Value),
                    isFavorite = true
                };

                if (!discounts.Any())
                {
                    productDto.Discount = 0;
                }
                else
                {
                    productDto.Discount = discounts.Where(x => x.Product_ID == item.Product_ID).Select(x => x.Value).FirstOrDefault();
                }

                productCardDtos.Add(productDto);
            }

            var result = PagedList<ProductCardDto>.ToPagedList(productCardDtos, model.page, 10);

            return new Response<PagedList<ProductCardDto>>()
            {
                Result = result,
                Description = "OK",
                StatusCode = StatusCode.OK
            };
        }

        public async Task<IBaseResponce<string>> AddFavorite(uint product_id, string token)
        {
            try
            {
                var user_id = JwtTokens.GetPayloadUser(token);

                Favorite favorite = new Favorite()
                {
                    Id = 0,
                    Product_ID = product_id,
                    User_ID = user_id
                };
                await _favoriteRepository.Create(favorite);

                return new Response<string>()
                {
                    Result = "OK",
                    Description = "Успешно",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<string>> RemoveFavorite(uint product_id, string token)
        {
            try
            {
                var user_id = JwtTokens.GetPayloadUser(token);
                var favorite = _favoriteRepository.Get().Where(x => x.Product_ID  == product_id && x.User_ID == user_id).FirstOrDefault();
                await _favoriteRepository.Delete(favorite);

                return new Response<string>()
                {
                    Result = "OK",
                    Description = "Успешно",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<string>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
