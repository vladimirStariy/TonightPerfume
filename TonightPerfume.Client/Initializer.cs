using TonightPerfume.Data;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Data.Repository.User;
using TonightPerfume.Domain.Models.Product;
using TonightPerfume.Domain.Models.User;
using TonightPerfume.Service.AutoMapper;
using TonightPerfume.Service.Services.ProductServ;
using TonightPerfume.Service.Services.UserServ;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TonightPerfume.Client
{
    public static class Initializer
    {

        //public static void InitializeDbContext(this IServiceCollection services)
        //{
            
        //}

        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));
        }

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
