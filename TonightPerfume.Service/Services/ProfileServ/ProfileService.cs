using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.DiscountR;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Utils;
using TonightPerfume.Domain.Viewmodels.ProductVM;
using TonightPerfume.Domain.Viewmodels.ProfileVM;

namespace TonightPerfume.Service.Services.ProfileServ
{
    public class ProfileService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Favorite> _favoritesRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Price> _priceRepository;
        private readonly IRepository<Discount> _discountRepository;

        public ProfileService(
            IRepository<Order> orderRepository,
            IRepository<Favorite> favoritesRepository, 
            IRepository<Product> productRepository,
            IRepository<Price> priceRepository
        )
        {
            _orderRepository = orderRepository;
            _favoritesRepository = favoritesRepository;
            _productRepository = productRepository;
            _priceRepository = priceRepository;
        }

        public async Task<IBaseResponce<List<UserOrderCardDto>>> GetOrders(uint id)
        {
            try
            {
                var orders = _orderRepository.Get().Where(x => x.User_ID == id);

                if (!orders.Any())
                {
                    return new Response<List<UserOrderCardDto>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                List<UserOrderCardDto> orderCards = new List<UserOrderCardDto>();
                foreach(var item in orders)
                {
                    UserOrderCardDto card = new UserOrderCardDto()
                    {
                        OrderDate = item.Order_date,
                        OrderPrice = (int)item.SummaryPrice,
                    };
                    if (item.isCanceled) card.Status = "Отменён";
                    if (item.isCompleted) card.Status = "Выполнен";
                    if (!item.isCompleted) card.Status = "Выполняется";
                    orderCards.Add(card);
                }

                return new Response<List<UserOrderCardDto>>()
                {
                    Result = orderCards,
                    Description = "Ok",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<UserOrderCardDto>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        
    }
}
