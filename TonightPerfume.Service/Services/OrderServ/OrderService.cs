using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.OrderVM;

namespace TonightPerfume.Service.Services.OrderServ
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Price> _priceRepository;
        private readonly IRepository<OrderProduct> _orderProductRepository;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            IRepository<Price> priceRepository,
            IRepository<OrderProduct> orderProductRepository
        ) 
        { 
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _priceRepository = priceRepository;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<IBaseResponce<string>> CreateOrderUnauthorized(OrderRequestDto model)
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
                    PaymentType = model.PaymentType,
                    isCanceled = false,
                    isCompleted = false,
                    OrderProducts = new List<OrderProduct>()
                };

                await _orderRepository.Create(order);

                int summaryPrice = 0;
                foreach(var item in model.products)
                {
                    var product = _priceRepository.Get().Where(x => x.Product_ID == item.product_id && 
                                                                    x.Volume_ID == item.volume_id).FirstOrDefault();

                    summaryPrice = summaryPrice + (product.Value * item.quantity);

                    var orderProduct = new OrderProduct() { 
                        Order_ID = order.Order_ID,
                        Price_ID = product.Price_ID,
                        Quantity = item.quantity
                    };

                    await _orderProductRepository.Create(orderProduct);
                }

                order.SummaryPrice = summaryPrice;

                await _orderRepository.Update(order);

                return new Response<string>()
                {
                    Result = "ok",
                    Description = "Заказ добавлен",
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

        public async Task<IBaseResponce<string>> CreateOrderAuthorized(OrderRequestDto model)
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
                    PaymentType = model.PaymentType,
                    Note = model.Note,
                    isCanceled = false,
                    isCompleted = false,
                    OrderProducts = new List<OrderProduct>()
                };

                await _orderRepository.Create(order);

                int summaryPrice = 0;
                foreach (var item in model.products)
                {
                    var product = _priceRepository.Get().Where(x => x.Product_ID == item.product_id &&
                                                                    x.Volume_ID == item.volume_id).FirstOrDefault();

                    summaryPrice = summaryPrice + (product.Value * item.quantity);

                    var orderProduct = new OrderProduct()
                    {
                        Order_ID = order.Order_ID,
                        Price_ID = product.Price_ID,
                        Quantity = item.quantity
                    };

                    await _orderProductRepository.Create(orderProduct);
                }

                order.SummaryPrice = summaryPrice;

                await _orderRepository.Update(order);

                return new Response<string>()
                {
                    Result = "ok",
                    Description = "Заказ добавлен",
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
