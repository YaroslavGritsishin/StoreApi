using AutoMapper;
using Domain;
using EntitiesDataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers
{
    public static class OrderElementMapper
    {
        public static OrderElementEntity ToEntity(this OrderElement element)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderElement, OrderElementEntity>());
            var mapper = new Mapper(config);
            return mapper.Map<OrderElement, OrderElementEntity>(element);
        }
        public static IEnumerable<OrderElementEntity> ToEntity(this IEnumerable<OrderElement> elements)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderElement, OrderElementEntity>()
                .ForMember("Product", opt => opt.MapFrom(src => src.Product)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<OrderElement>, IEnumerable<OrderElementEntity>>(elements);
        }


        public static OrderElement ToDomain(this OrderElementEntity element)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderElementEntity, OrderElement>());
            var mapper = new Mapper(config);
            return mapper.Map<OrderElementEntity, OrderElement>(element);
        }
        public static IEnumerable<OrderElement> ToDomain(this IEnumerable<OrderElementEntity> elements)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderElementEntity, OrderElement>()
                .ForMember("Product", opt => opt.MapFrom(src => src.Product)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<OrderElementEntity>, IEnumerable<OrderElement>>(elements);
        }
    }
}
