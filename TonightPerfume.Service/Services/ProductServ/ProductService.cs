using Microsoft.AspNetCore.Http;
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
        private readonly IRepository<ProductNotes> _productNotesRepository;

        public ProductService(
            IRepository<Product> productRepository,
            IRepository<PerfumeNote> perfumeNotesRepository,
            IRepository<Discount> discountRepository,
            IRepository<Price> priceRepository,
            IRepository<Brand> brandRepository,
            IRepository<Category> categoryRepository,
            IRepository<AromaGroup> aromaGroupRepository,
            IRepository<Favorite> favoriteRepository,
            IRepository<ProductNotes> productNotesRepository
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
            _productNotesRepository = productNotesRepository;
        }

        public async Task<IBaseResponce<ProductAddDto>> Create(IFormFile file, ProductAddDto model)
        {
            try
            {
                var _notes = new List<PerfumeNote>();
                var _aromaGroups = new List<AromaGroup>();

                foreach (var item in model.groups) { _aromaGroups.Add(await _aromaGroupRepository.GetById(item)); }
                foreach (var item in model.upperNotes) { _notes.Add(await _perfumeNotesRepository.GetById(item)); }
                foreach (var item in model.middleNotes) { _notes.Add(await _perfumeNotesRepository.GetById(item)); }
                foreach (var item in model.bottomNotes) { _notes.Add(await _perfumeNotesRepository.GetById(item)); }

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SiteImages/Products");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                FileInfo fileInfo = new FileInfo(file.FileName);
                string fileNameWithPath = Path.Combine(path, file.FileName);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
                var newProduct = new Product()
                {
                    Name = model.name,
                    Description = model.description,
                    Brand_ID = model.brand,
                    Category_ID = model.category,
                    Year = model.year,
                    ImagePath = $"SiteImages/Products/{file.FileName}",
                    Country = model.country,
                    isPopular = model.isPopular,
                    isForOrder = model.isForOrder,
                    AromaGroups = _aromaGroups,
                    
                };

                await _productRepository.Create(newProduct);

                if(!model.isForOrder)
                {
                    foreach (var item in model.Prices)
                    {
                        if(item.priceValue != 0)
                        {
                            Price price = new Price()
                            {
                                Product_ID = newProduct.Product_ID,
                                Volume_ID = item.volumeId,
                                Value = item.priceValue
                            };
                            await _priceRepository.Create(price);
                        }
                    }
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

        public async Task<IBaseResponce<ProductDto>> GetById(uint id)
        {
            try
            {
                var product = await _productRepository.GetById(id);
                var prices = _priceRepository.Get().Where(x => x.Product_ID == id);
                var notes = _productNotesRepository.Get().Where(x => x.Product_ID == id).ToList();

                var productDto = new ProductDto()
                {
                    Id = product.Product_ID,
                    Name = product.Name,
                    Description = product.Description,
                    Prices = prices.ToList(),
                    Brand = product.Brand,
                    Country = product.Country,
                    Year = product.Year,
                    Category = product.Category,
                    AromaGroups = product.AromaGroups,
                    PerfumeNotes = notes,
                    ImagePath = product.ImagePath,
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

        public async Task<IBaseResponce<List<countryvm>>> GetSortedCountries()
        {
            try
            {
                var countries = _productRepository.Get().ToList().OrderBy(x => x.Country).Select(x => x.Country).Distinct();

                List<countryvm> countriesDto = new List<countryvm>();
                foreach(var item in countries)
                {
                    countryvm countryDto = new countryvm();
                    countryDto.name = item;
                    countriesDto.Add(countryDto);
                }

                return new Response<List<countryvm>>()
                {
                    Result = countriesDto,
                    Description = "OK",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<countryvm>>()
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
                var countries = _productRepository.Get().ToList().OrderBy(x => x.Country).Select(x => x.Country).Distinct().Take(count);
                var prices = _priceRepository.Get().ToList();
                var minPrice = prices.Min(x => x.Value);
                var maxPrice = prices.Max(x => x.Value);

                FilterDto filterDto = new FilterDto()
                {
                    AromaGroups = aromaGroups.ToList(),
                    Brands = brands.ToList(),
                    Categories = categories.ToList(),
                    PerfumeNotes = notes.ToList(),
                    Countries = countries.ToList(),
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                };

                return new Response<FilterDto>()
                {
                    Result = filterDto,
                    Description = "OK",
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

        public async Task<IBaseResponce<List<ProductCardDto>>> GetPopularProducts()
        {
            try
            {
                var products = _productRepository.Get().Where(x => x.isPopular).ToList();
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
                        Price = prices.Where(x => x.Product_ID == item.Product_ID).Min(x => x.Value),
                        Prices = prices.Where(x => x.Product_ID == item.Product_ID).ToList(),
                        imagePath = item.ImagePath
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

        public async Task<IBaseResponce<PagedList<ProductCardDto>>> GetFilteredProductsWithPagination(FilterRequestDto model, string token)
        {
            try
            {
                if(!model.isForOrder)
                {
                    var perfumeNotes = new List<PerfumeNote>();
                    var prices = new List<Price>();

                    var products = _productRepository.Get().Where(x => x.isForOrder == false);

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
                        products = products.Where(x => x.ProductNotes.Any(y => model.PerfumeNotes.Contains((int)y.Note_ID)));
                    }
                    if (model.AromaGroups.Count > 0)
                    {
                        products = products.Where(x => x.AromaGroups.Any(y => model.AromaGroups.Contains((int)y.AromaGroup_ID)));
                    }
                    if (model.Countries.Count > 0)
                    {
                        products = products.Where(x => model.Countries.Contains(x.Country));
                    }
                    if (model.Prices.Length > 0)
                    {
                        prices = _priceRepository.Get().Where(x => x.Value >= model.Prices[0] && x.Value <= model.Prices[1]).ToList();
                        if(model.Volumes.Count > 0)
                        {
                            prices = prices.Where(x => model.Volumes.Contains(x.Volume.Value)).ToList();
                        }
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
                        List<Price> _prices = null;
                        try
                        {
                            _price = prices.Where(x => x.Product_ID == item.Product_ID).Min(x => x.Value);
                            _prices = prices.Where(x => x.Product_ID == item.Product_ID).ToList();
                        }
                        catch
                        {
                            _prices = null;
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
                            Prices = _prices,
                            imagePath = item.ImagePath,
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

                    if(model.sortType == "alph")
                    {
                        productCardDtos = productCardDtos.OrderBy(x => x.Name).ToList();
                    }
                    if(model.sortType == "priceASC")
                    {
                        productCardDtos = productCardDtos.OrderBy(x => x.Price).ToList();
                    }
                    if(model.sortType == "priceDESC")
                    {
                        productCardDtos = productCardDtos.OrderByDescending(x => x.Price).ToList();
                    }

                    var result = PagedList<ProductCardDto>.ToPagedList(productCardDtos, model.Page, 24);

                    return new Response<PagedList<ProductCardDto>>()
                    {
                        Result = result,
                        Description = "Успешно",
                        StatusCode = StatusCode.OK
                    };
                } 
                else
                {
                    var perfumeNotes = new List<PerfumeNote>();

                    var products = _productRepository.Get().Where(x => x.isForOrder == true);

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
                        products = products.Where(x => x.ProductNotes.Any(y => model.PerfumeNotes.Contains((int)y.Note_ID)));
                    }
                    if (model.AromaGroups.Count > 0)
                    {
                        products = products.Where(x => x.AromaGroups.Any(y => model.AromaGroups.Contains((int)y.AromaGroup_ID)));
                    }
                    if (model.Countries.Count > 0)
                    {
                        products = products.Where(x => model.Countries.Contains(x.Country));
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
                        bool isFavorite = false;
                        if (token != null)
                        {
                            if (favorites.Contains(item.Product_ID))
                                isFavorite = true;
                        }

                        var productDto = new ProductCardDto()
                        {
                            Id = item.Product_ID,
                            Name = item.Name,
                            Brand = item.Brand.Name,
                            imagePath = item.ImagePath,
                            isFavorite = isFavorite,
                            isForOrder = true
                        };

                        productCardDtos.Add(productDto);
                    }

                    if (model.sortType == "alph")
                    {
                        productCardDtos = productCardDtos.OrderBy(x => x.Name).ToList();
                    }
                    if (model.sortType == "priceASC")
                    {
                        productCardDtos = productCardDtos.OrderBy(x => x.Price).ToList();
                    }
                    if (model.sortType == "priceDESC")
                    {
                        productCardDtos = productCardDtos.OrderByDescending(x => x.Price).ToList();
                    }

                    var result = PagedList<ProductCardDto>.ToPagedList(productCardDtos, model.Page, 24);

                    return new Response<PagedList<ProductCardDto>>()
                    {
                        Result = result,
                        Description = "Успешно",
                        StatusCode = StatusCode.OK
                    };
                }
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

        public async Task<IBaseResponce<PagedList<ProductCardDto>>> GetFilteredProductsForOrderWithPagination(FilterRequestDto model, string token)
        {
            try
            {
                var perfumeNotes = new List<PerfumeNote>();

                var products = _productRepository.Get().Where(x => x.isForOrder);

                if (model.Brands.Count > 0)
                {
                    products = products.Where(x => model.Brands.Contains((int)x.Brand_ID));
                }
                if (model.Categories.Count > 0)
                {
                    products = products.Where(x => model.Categories.Contains((int)x.Category_ID));
                }
                //if (model.PerfumeNotes.Count > 0)
                //{
                //    products = products.Where(x => x.PerfumeNotes.Any(y => model.PerfumeNotes.Contains((int)y.Note_ID)));
                //}
                if (model.AromaGroups.Count > 0)
                {
                    products = products.Where(x => x.AromaGroups.Any(y => model.AromaGroups.Contains((int)y.AromaGroup_ID)));
                }
                if (model.Countries.Count > 0)
                {
                    products = products.Where(x => model.Countries.Contains(x.Country));
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
                    bool isFavorite = false;
                    if (token != null)
                    {
                        if (favorites.Contains(item.Product_ID))
                            isFavorite = true;
                    }

                    var productDto = new ProductCardDto()
                    {
                        Id = item.Product_ID,
                        Name = item.Name,
                        Brand = item.Brand.Name,
                        imagePath = item.ImagePath,
                        isFavorite = isFavorite,
                    };

                    productCardDtos.Add(productDto);
                }

                var result = PagedList<ProductCardDto>.ToPagedList(productCardDtos, model.Page, 24);

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
                    isFavorite = true,
                    isForOrder = item.isForOrder,
                    imagePath = item.ImagePath
                };

                if(!item.isForOrder)
                {
                    productDto.Price = prices.Where(x => x.Product_ID == item.Product_ID).Min(x => x.Value);
                    productDto.Prices = prices.Where(x => x.Product_ID == item.Product_ID).ToList();
                }

                if(!item.isForOrder)
                {
                    if (!discounts.Any())
                    {
                        productDto.Discount = 0;
                    }
                    else
                    {
                        productDto.Discount = discounts.Where(x => x.Product_ID == item.Product_ID).Select(x => x.Value).FirstOrDefault();
                    }
                }

                productCardDtos.Add(productDto);
            }

            var result = PagedList<ProductCardDto>.ToPagedList(productCardDtos, model.page, 24);

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

        public async Task<IBaseResponce<ProductPropertiesDto>> GetProductProperties()
        {
            try
            {
                var productPropertiesDto = new ProductPropertiesDto();
                productPropertiesDto.categories = _categoryRepository.Get().ToList();
                productPropertiesDto.perfumeNotes = _perfumeNotesRepository.Get().ToList();
                productPropertiesDto.brands = _brandRepository.Get().ToList();
                productPropertiesDto.aromaGroups = _aromaGroupRepository.Get().ToList();

                return new Response<ProductPropertiesDto>()
                {
                    Result = productPropertiesDto,
                    Description = "Успешно",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductPropertiesDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<List<ProductTableDto>>> GetTableProducts()
        {
            try
            {
                var products = _productRepository.Get().ToList();
                List<ProductTableDto> productsDto = new List<ProductTableDto>();
                foreach(var product in products)
                {
                    var tableProductDto = new ProductTableDto();
                    tableProductDto.productId = product.Product_ID;
                    tableProductDto.name = product.Name;
                    tableProductDto.brand = product.Brand.Name;
                    tableProductDto.category = product.Category.Name;
                    productsDto.Add(tableProductDto);
                }

                return new Response<List<ProductTableDto>>()
                {
                    Result = productsDto,
                    Description = "Успешно",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<ProductTableDto>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
