using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.OrderVM;

namespace TonightPerfume.Service.Services.OrderServ
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Price> _priceRepository;

        public OrderService(
            IRepository<Order> orderRepository, 
            IRepository<Product> productRepository,
            IRepository<Price> priceRepository
        ) 
        { 
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _priceRepository = priceRepository;
        }

        public async Task CreateOrderUnauthorized(OrderRequestDto model)
        {
            try
            {
                var order = new Order()
                {
                    Order_date = DateTime.Now,
                    isNew = true,
                    FirstName = model.Firstname,
                    Lastname = model.Lastname,
                    Surname = model.Surname,
                    Phone = model.Phone,
                    Email = model.Email,
                    City = model.City,
                    Region = model.Region,
                    Appartaments = model.Appartaments,
                    DomophoneCode = model.DomophoneCode,
                    Entrance = model.Entrance,
                    Floor = model.Floor,
                    DeliveryType = model.DeliveryType,
                    Note = model.Note,
                    isCanceled = false,
                    isCompleted = false,
                };

                await _orderRepository.Create(order);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
