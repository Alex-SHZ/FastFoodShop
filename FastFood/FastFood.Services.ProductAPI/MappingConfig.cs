using System;
using AutoMapper;
using FastFood.Services.ProductAPI.Models;
using FastFood.Services.ProductAPI.Models.DTO;

namespace FastFood.Services.ProductAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDTO, Product>();
            config.CreateMap<Product, ProductDTO>();
        });

        return mappingConfig;
    }
}

