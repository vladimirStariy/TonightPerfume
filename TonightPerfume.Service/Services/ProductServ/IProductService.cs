using Microsoft.AspNetCore.Http;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Utils;
using TonightPerfume.Domain.Viewmodels.Filter;
using TonightPerfume.Domain.Viewmodels.ProductVM;
using TonightPerfume.Domain.Viewmodels.ProfileVM;

namespace TonightPerfume.Service.Services.ProductServ
{
    public interface IProductService
    {
        Task<IBaseResponce<ProductAddDto>> Create(IFormFile file, ProductAddDto model);
        Task<IBaseResponce<PagedList<ProductCardDto>>> GetProductsWithPagination(int page);
        Task<IBaseResponce<ProductDto>> GetById(uint id);
        Task<IBaseResponce<FilterDto>> GetFilter(int count);
        Task<IBaseResponce<PagedList<ProductCardDto>>> GetFilteredProductsWithPagination(FilterRequestDto model, string token);
        Task<IBaseResponce<PagedList<ProductCardDto>>> GetFilteredProductsForOrderWithPagination(FilterRequestDto model, string token);
        Task<IBaseResponce<PagedList<ProductCardDto>>> GetFavorites(FavoriteRequestDto model);
        Task<IBaseResponce<string>> AddFavorite(uint product_id, string token);
        Task<IBaseResponce<string>> RemoveFavorite(uint product_id, string token);
        Task<IBaseResponce<List<countryvm>>> GetSortedCountries();
        Task<IBaseResponce<List<ProductCardDto>>> GetPopularProducts();
        Task<IBaseResponce<ProductPropertiesDto>> GetProductProperties();
        Task<IBaseResponce<List<ProductTableDto>>> GetTableProducts();
    }
}