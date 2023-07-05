using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Data.Repository.User;
using TonightPerfume.Domain.Models.Product;
using TonightPerfume.Domain.Models.User;
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
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
