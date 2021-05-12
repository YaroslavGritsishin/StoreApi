using AutoMapper;
using Domain;
using EntitiesDataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers
{
    public static class OrderMapper
    {
        public static OrderEntity ToEntity(this Order order)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderEntity>());
            var mapper = new Mapper(config);
            return mapper.Map<Order, OrderEntity>(order);
        }
        public static IEnumerable<OrderEntity> ToEntity(this IEnumerable<Order> order)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderEntity>()
                .ForMember("OrderElements", opt => opt.MapFrom(src => src.OrderElements)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderEntity>>(order);
        }


        public static Order ToDomain(this OrderEntity customer)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderEntity, Order>());
            var mapper = new Mapper(config);
            return mapper.Map<OrderEntity, Order>(customer);
        }
        public static IEnumerable<Order> ToDomain(this IEnumerable<OrderEntity> customer)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderEntity, Order>()
                .ForMember("OrderElements", opt => opt.MapFrom(src => src.OrderElements)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<OrderEntity>, IEnumerable<Order>>(customer);
        }

    }
}
