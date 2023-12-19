using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Security;
using TonightPerfume.Domain.Viewmodels.OrderVM;

namespace TonightPerfume.Service.Services.OrderServ
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Promocode> _promocodeRepository;
        private readonly IRepository<Price> _priceRepository;
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IRepository<Discount> _discountRepository;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            IRepository<Price> priceRepository,
            IRepository<OrderProduct> orderProductRepository,
            IRepository<Promocode> promocodeRepository,
            IRepository<Discount> discountRepository
        ) 
        { 
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _priceRepository = priceRepository;
            _orderProductRepository = orderProductRepository;
            _promocodeRepository = promocodeRepository;
            _discountRepository = discountRepository;
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
                    PostNumber = model.PostNumber,
                    DeliveryType = model.DeliveryType,
                    Note = model.Note,
                    PaymentType = model.PaymentType,
                    Promocode = model.promocode,
                    isCanceled = false,
                    isCompleted = false,
                    OrderProducts = new List<OrderProduct>()
                };

                await _orderRepository.Create(order);

                int summaryPrice = 0;
                int promocodeDiscount = 0;

                if(model.promocode != null || model.promocode != "")
                {
                    var currPromocode = _promocodeRepository.Get().Where(x => x.PromocodeBody == model.promocode).FirstOrDefault();
                    if(currPromocode != null) 
                    {
                        promocodeDiscount = Convert.ToInt32(currPromocode.Value);
                    }
                }
                foreach(var item in model.products)
                {
                    var product = _priceRepository.Get().Where(x => x.Product_ID == item.productId && 
                                                                    x.Volume_ID == item.volumeId).FirstOrDefault();

                    var productDiscount = _discountRepository.Get().Where(x => x.Product_ID == item.productId).FirstOrDefault();
                    
                    int productPrice = product.Value;

                    if(productDiscount != null)
                    {
                        if(productDiscount.Value > promocodeDiscount || productDiscount.Value == promocodeDiscount)
                        {
                            productPrice = productPrice - ((productPrice / 100) * productDiscount.Value);
                        }
                        else
                        {
                            productPrice = productPrice - ((productPrice / 100) * promocodeDiscount);
                        }
                    }
                    else if(productDiscount == null)
                    {
                        productPrice = productPrice - ((productPrice / 100) * promocodeDiscount);
                    }

                    summaryPrice = summaryPrice + (productPrice * item.quantity);

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

        public async Task<IBaseResponce<string>> CreateOrderAuthorized(OrderRequestDto model, string token)
        {
            var user_id = JwtTokens.GetPayloadUser(token);

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
                    PostNumber = model.PostNumber,
                    Promocode = model.promocode,
                    isCanceled = false,
                    isCompleted = false,
                    User_ID = user_id,
                    OrderProducts = new List<OrderProduct>()
                };

                await _orderRepository.Create(order);

                int summaryPrice = 0;
                int promocodeDiscount = 0;

                if (model.promocode != null || model.promocode != "")
                {
                    var currPromocode = _promocodeRepository.Get().Where(x => x.PromocodeBody == model.promocode).FirstOrDefault();
                    if (currPromocode != null)
                    {
                        promocodeDiscount = Convert.ToInt32(currPromocode.Value);
                    }
                }
                foreach (var item in model.products)
                {
                    var product = _priceRepository.Get().Where(x => x.Product_ID == item.productId &&
                                                                    x.Volume_ID == item.volumeId).FirstOrDefault();

                    var productDiscount = _discountRepository.Get().Where(x => x.Product_ID == item.productId).FirstOrDefault();

                    int productPrice = product.Value;

                    if (productDiscount != null)
                    {
                        if (productDiscount.Value > promocodeDiscount || productDiscount.Value == promocodeDiscount)
                        {
                            productPrice = productPrice - ((productPrice / 100) * productDiscount.Value);
                        }
                        else
                        {
                            productPrice = productPrice - ((productPrice / 100) * promocodeDiscount);
                        }
                    }
                    else if (productDiscount == null)
                    {
                        productPrice = productPrice - ((productPrice / 100) * promocodeDiscount);
                    }

                    summaryPrice = summaryPrice + (productPrice * item.quantity);

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

        public async Task<IBaseResponce<string>> GetPromocodeData(string promocode)
        {
            try
            {
                var currPromocode = _promocodeRepository.Get().Where(x => x.PromocodeBody == promocode).FirstOrDefault();
                if (currPromocode != null)
                {
                    var expirationResult = DateTime.Compare(currPromocode.ExpirationDate, DateTime.UtcNow);
                    if(expirationResult > 0)
                    {
                        return new Response<string>()
                        {
                            Result = currPromocode.Value,
                            Description = "ОК",
                            StatusCode = StatusCode.OK
                        };
                    } 
                    else
                    {
                        return new Response<string>()
                        {
                            StatusCode = StatusCode.InternalServerError,
                            Description = $"Промокод просрочен."
                        };
                    }
                }
                else
                {
                    return new Response<string>()
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = $"Промокод не найден."
                    };
                }
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
