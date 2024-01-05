using Microsoft.AspNetCore.Http;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;

namespace TonightPerfume.Service.Services.ProductServ.Interfaces
{
    public interface IBrandService
    {
        Task<IBaseResponce<Brand>> Create(IFormFile file, Brand model);
        Task<IBaseResponce<List<Brand>>> Get();
        Task<IBaseResponce<List<Brand>>> GetSomeBrands(int count);
        Task<IBaseResponce<List<Brand>>> GetSortedBrands();
    }
}
