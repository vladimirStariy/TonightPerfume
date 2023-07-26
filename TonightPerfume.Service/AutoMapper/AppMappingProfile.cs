﻿using AutoMapper;
using System;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Viewmodels.ProductVM;

namespace TonightPerfume.Service.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Product, ProductCardViewModel>();
        }
    }
}
