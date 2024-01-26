using Newtonsoft.Json.Linq;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Enum;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Security;
using TonightPerfume.Domain.Viewmodels.ProfileVM;

namespace TonightPerfume.Service.Services.ProfileServ
{
    public class ProfileService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<Adress> _adressRepository;
        private readonly IRepository<Favorite> _favoritesRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Price> _priceRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<OrderProduct> _orderProductRepository;

        public ProfileService(
            IRepository<Order> orderRepository,
            IRepository<OrderProduct> orderProductRepository,
            IRepository<Favorite> favoritesRepository,
            IRepository<Product> productRepository,
            IRepository<Price> priceRepository,
            IRepository<Profile> profileRepository,
            IRepository<Adress> adressRepository
        )
        {
            _orderRepository = orderRepository;
            _favoritesRepository = favoritesRepository;
            _productRepository = productRepository;
            _priceRepository = priceRepository;
            _profileRepository = profileRepository;
            _adressRepository = adressRepository;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<IBaseResponce<List<UserOrderCardDto>>> GetOrders(string token)
        {
            try
            {
                var user_id = JwtTokens.GetPayloadUser(token);

                var orders = _orderRepository.Get().Where(x => x.User_ID == user_id);

                if (!orders.Any())
                {
                    return new Response<List<UserOrderCardDto>>()
                    {
                        Description = "Not found",
                        StatusCode = StatusCode.OK
                    };
                }

                List<UserOrderCardDto> orderCards = new List<UserOrderCardDto>();
                foreach (var item in orders)
                {
                    UserOrderCardDto card = new UserOrderCardDto()
                    {
                        OrderId = item.Order_ID,
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

        public async Task<IBaseResponce<List<OrderProductDto>>> GetOrderProducts(uint orderId) 
        {
            try
            {               
                var orderProductsDto = new List<OrderProductDto>();
                var orderProducts = _orderProductRepository.Get().Where(x => x.Order_ID == orderId).ToList();
                var products = _productRepository.Get().Where(x => orderProducts.Select(y => y.Price.Product_ID).Contains(x.Product_ID));

                foreach (var orderProduct in orderProducts)
                {
                    OrderProductDto productDto = new OrderProductDto()
                    {
                        productId = orderProduct.Price.Product_ID,
                        quantity = orderProduct.Quantity,
                        productBrand = products.Where(x => x.Product_ID == orderProduct.Price.Product_ID).Select(y => y.Brand.Name).FirstOrDefault(),
                        productName = products.Where(x => x.Product_ID == orderProduct.Price.Product_ID).Select(y => y.Name).FirstOrDefault(),
                        price = orderProduct.Quantity * orderProduct.Price.Value,
                        image = products.Where(x => x.Product_ID == orderProduct.Price.Product_ID).Select(y => y.ImagePath).FirstOrDefault()
                    };
                    orderProductsDto.Add(productDto);
                }

                return new Response<List<OrderProductDto>>()
                {
                    Result = orderProductsDto,
                    Description = "Ok",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<OrderProductDto>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<string>> UpdateProfile(UpdateProfileDto dto, string token)
        {
            try
            {
                var user_id = JwtTokens.GetPayloadUser(token);
                var profile = _profileRepository.Get().Where(x => x.User_ID == user_id).FirstOrDefault();

                profile.Firstname = dto.Firstname;
                profile.Middlename = dto.Middlename;
                profile.Lastname = dto.Lastname;
                profile.Birthday = dto.Birthday;
                profile.Email = dto.Email;
                profile.Phone = dto.Phone;

                await _profileRepository.Update(profile);

                return new Response<string>()
                {
                    Result = "ok",
                    Description = "Ok",
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

        public async Task<IBaseResponce<ProfileAdressDto>> AddAdress(ProfileAdressDto profileAdress, string token)
        {
            try
            {
                var user_id = JwtTokens.GetPayloadUser(token);
                var profile_id = _profileRepository.Get().Where(x => x.User_ID == user_id).Select(x => x.Profile_ID).FirstOrDefault();
                var adress = new Adress()
                {
                    Name = profileAdress.Name == "" ? "Без имени" : profileAdress.Name,
                    City = profileAdress.City,
                    Region = profileAdress.Region,
                    Appartaments = profileAdress.Appartaments,
                    DomophoneCode = profileAdress.DomophoneCode,
                    Entrance = profileAdress.Entrance,
                    Floor = profileAdress.Floor,
                    PostNumber = profileAdress.PostNumber,
                    Profile_ID = profile_id,
                    DeliveryType = profileAdress.DeliveryType
                };

                await _adressRepository.Create(adress);

                return new Response<ProfileAdressDto>()
                {
                    Result = profileAdress,
                    Description = "Ok",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex) 
            {
                return new Response<ProfileAdressDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<Adress>> DeleteAdress(uint adress_id, string token)
        {
            try
            {
                var user_id = JwtTokens.GetPayloadUser(token);
                var adress = await _adressRepository.GetById(adress_id);

                if(adress.Profile.User_ID ==  user_id)
                {
                    await _adressRepository.Delete(adress);

                    return new Response<Adress>()
                    {
                        Result = adress,
                        Description = "Ok",
                        StatusCode = StatusCode.OK
                    };
                }

                return new Response<Adress>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Unautorized"
                };
            }
            catch (Exception ex)
            {
                return new Response<Adress>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<ProfileDataDto>> GetProfileData(string token)
        {
            try
            {
                var user_id = JwtTokens.GetPayloadUser(token);
                var profile = _profileRepository.Get().Where(x => x.User_ID == user_id).FirstOrDefault();
                var addreses = _adressRepository.Get().Where(x => x.Profile_ID == profile.Profile_ID);

                var profileData = new ProfileDataDto();

                foreach(var adress in addreses)
                {
                    var profileAdress = new ProfileAdressDto()
                    {
                        Id = adress.Adress_ID,
                        Name = adress.Name,
                        City = adress.City,
                        Region = adress.Region,
                        Appartaments = adress.Appartaments,
                        DomophoneCode = adress.DomophoneCode,
                        Entrance = adress.Entrance,
                        Floor = adress.Floor,
                        PostNumber = adress.PostNumber,
                        DeliveryType = adress.DeliveryType,
                    };
                    profileData.ProfileAdresses.Add(profileAdress);
                }

                profileData.Firstname = profile.Firstname;
                profileData.Middlename = profile.Middlename;
                profileData.Lastname = profile.Lastname;
                profileData.Birthday = profile.Birthday;
                profileData.Email = profile.Email;
                profileData.Phone = profile.Phone;
                profileData.AccumulativeDiscount = profile.AccumulativeDiscount;
                profileData.DiscountProgress = profile.DiscountProgress;

                return new Response<ProfileDataDto>()
                {
                    Result = profileData,
                    Description = "Ok",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<ProfileDataDto>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}
