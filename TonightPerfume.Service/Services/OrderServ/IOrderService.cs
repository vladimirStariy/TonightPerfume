using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.OrderVM;

namespace TonightPerfume.Service.Services.OrderServ
{
    public interface IOrderService
    {
        Task<IBaseResponce<string>> CreateOrderUnauthorized(OrderRequestDto model);
        Task<IBaseResponce<string>> CreateOrderAuthorized(OrderRequestDto model, string token);
        Task<IBaseResponce<string>> GetPromocodeData(string promocode);
    }
}
