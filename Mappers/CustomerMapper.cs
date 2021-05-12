using AutoMapper;
using Domain;
using EntitiesDataLayer;
using System.Collections.Generic;

namespace Mappers
{
    public static class CustomerMapper
    {
        public static CustomerEntity ToEntity(this Customer customer)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountEntity>()
                .ForMember(e => e.Email, opt => opt.MapFrom(src => src.Email));

                cfg.CreateMap<Customer, CustomerEntity>()
                .ForMember(e => e.Account, opt => opt.MapFrom(src => src.Account));

                cfg.CreateMap<Order, OrderEntity>()
                .ForMember(e => e.OrderDate, opt => opt.MapFrom(src => src.OrderDate));

                cfg.CreateMap<Customer, CustomerEntity>()
                .ForMember(e => e.Orders, opt => opt.MapFrom(src => src.Orders));

            });


            var mapper = new Mapper(config);
            return mapper.Map<Customer, CustomerEntity>(customer);
        }
        public static IEnumerable<CustomerEntity> ToEntity(this IEnumerable<Customer> customer)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerEntity>()
                .ForMember("Orders", opt => opt.MapFrom(src => src.Orders)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerEntity>>(customer);
        }


        public static Customer ToDomain(this CustomerEntity customer)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerEntity, Customer>());
            var mapper = new Mapper(config);
            return mapper.Map<CustomerEntity, Customer>(customer);
        }
        public static IEnumerable<Customer> ToDomain(this IEnumerable<CustomerEntity> customer)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AccountEntity, Account>()
                .ForMember(e => e.Email, opt => opt.MapFrom(src => src.Email));

                cfg.CreateMap<CustomerEntity, Customer>()
                .ForMember(e => e.Account, opt => opt.MapFrom(src => src.Account));

                cfg.CreateMap<OrderEntity, Order>()
                .ForMember(e => e.OrderDate, opt => opt.MapFrom(src => src.OrderDate));

                cfg.CreateMap<CustomerEntity, Customer>()
                .ForMember(e => e.Orders, opt => opt.MapFrom(src => src.Orders));
            });
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<CustomerEntity>, IEnumerable<Customer>>(customer);
        }
    }
}
