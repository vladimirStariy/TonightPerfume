using TonightPerfume.Domain.Viewmodels.OrderVM;

namespace TonightPerfume.Service.Services.OrderServ
{
    public interface IOrderService
    {
        Task CreateOrderUnauthorized(OrderRequestDto model);
    }
}
