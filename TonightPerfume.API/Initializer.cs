﻿using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Data.Repository.DiscountR;
using TonightPerfume.Data.Repository.OrderR;
using TonightPerfume.Data.Repository.ProductR;
using TonightPerfume.Data.Repository.ProfileR;
using TonightPerfume.Data.Repository.User;
using TonightPerfume.Domain.Models;
using TonightPerfume.Service.Services.AccountServ;
using TonightPerfume.Service.Services.DiscountServ;
using TonightPerfume.Service.Services.OrderServ;
using TonightPerfume.Service.Services.ProductServ;
using TonightPerfume.Service.Services.ProductServ.Implementations;
using TonightPerfume.Service.Services.ProductServ.Interfaces;
using TonightPerfume.Service.Services.ProfileServ;
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
            services.AddScoped<IRepository<AromaGroup>, AromaGroupRepository>();
            services.AddScoped<IRepository<Favorite>, FavoritesRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<OrderProduct>, OrderProductRepository>();
            services.AddScoped<IRepository<Profile>, ProfileRepository>();
            services.AddScoped<IRepository<Adress>, AdressRepository>();
            services.AddScoped<IRepository<Promocode>, PromocodeRepository>();
            services.AddScoped<IRepository<AtomizerColor>, AtomizerColorRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPerfumeNoteService, PerfumeNoteService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddScoped<IAromaGroupService, AromaGroupService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ProfileService>();
        }
    }
}
