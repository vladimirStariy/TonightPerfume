using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;

namespace TonightPerfume.Service.Services.ProductServ.Interfaces
{
    public interface IBrandService
    {
        Task<IBaseResponce<Brand>> Create(Brand model);
        Task<IBaseResponce<List<Brand>>> Get();
    }
}
