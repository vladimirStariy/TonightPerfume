using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Data.Repository.User;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.AccountServ;
using TonightPerfume.Service.Services.ProductServ;
using TonightPerfume.Service.Services.UserServ;

namespace TonightPerfume.API
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<BaseUser>, UserRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<ITokenRepository<RefreshToken>, TokenRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
