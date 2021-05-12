using AutoMapper;
using Domain;
using EntitiesDataLayer;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mappers
{
    public static class ProductMapper
    {
        public static ProductEntity ToEntity(this Product product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductEntity>());
            var mapper = new Mapper(config);
            return mapper.Map<Product, ProductEntity>(product);
        }
        public static IEnumerable<ProductEntity> ToEntity(this IEnumerable<Product> product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductEntity>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductEntity>>(product);
        }


        public static Product ToDomain(this ProductEntity product)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductEntity, Product>()
                .ForMember(dest => dest.Img, opt => opt.MapFrom(src => ConvertToBase64(src.ImgPath)));

            });
            var mapper = new Mapper(config);
            var res = mapper.Map<ProductEntity, Product>(product);
            return res;
        }

        public static IEnumerable<Product> ToDomain(this IEnumerable<ProductEntity> product)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductEntity, Product>()
                .ForMember(dest => dest.Img, opt => opt.MapFrom(src => ConvertToBase64(src.ImgPath)));
            });
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<ProductEntity>, IEnumerable<Product>>(product);
        }
        private static string ConvertToBase64(string path)
        {
            var imgBytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(imgBytes);
        }
    }
}
