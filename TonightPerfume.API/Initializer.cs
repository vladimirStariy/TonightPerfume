using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.DiscountR;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Data.Repository.User;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.AccountServ;
using TonightPerfume.Service.Services.DiscountServ;
using TonightPerfume.Service.Services.ProductServ;
using TonightPerfume.Service.Services.ProductServ.Implementations;
using TonightPerfume.Service.Services.ProductServ.Interfaces;
using TonightPerfume.Service.Services.UserServ;

namespace TonightPerfume.API
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<BaseUser>, UserRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<PerfumeNote>, PerfumeNoteRepository>();
            services.AddScoped<IRepository<Brand>, BrandRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<ITokenRepository<RefreshToken>, TokenRepository>();
            services.AddTransient<IRepository<Discount>, DiscountRepository>();
            services.AddScoped<IRepository<Price>, PriceRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPerfumeNoteService, PerfumeNoteService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<IDiscountService, DiscountService>();
        }
    }
}
