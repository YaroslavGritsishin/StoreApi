using AutoMapper;
using Domain;
using EntitiesDataLayer;
using System.Collections.Generic;
using System.Linq;

namespace Mappers
{
    public static class AccountMapper
    {
        public static AccountEntity ToEntity(this Account account)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountEntity>()
               .ForMember(e => e.Email, opt => opt.MapFrom(src => src.Email));

                cfg.CreateMap<Customer, CustomerEntity>()
                .ForMember(e => e.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<Account, AccountEntity>()
                .ForMember(e => e.Customer, opt => opt.MapFrom(src => src.Customer));

            });

            var mapper = new Mapper(config);
            return mapper.Map<Account, AccountEntity>(account);
        }
        public static IEnumerable<AccountEntity> ToEntity(this IEnumerable<Account> account)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Account, AccountEntity>()
                .ForMember("Role", opt => opt.MapFrom(src => src.Role))
                .ForMember("Customer", opt => opt.MapFrom(src => src.Customer)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Account>, IEnumerable<AccountEntity>>(account);
        }

        public static Account ToDomain(this AccountEntity account)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AccountEntity, Account>()
              .ForMember(e => e.Email, opt => opt.MapFrom(src => src.Email));

                cfg.CreateMap<CustomerEntity, Customer>()
                .ForMember(e => e.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<AccountEntity, Account>()
                .ForMember(e => e.Customer, opt => opt.MapFrom(src => src.Customer));
            }); 
            var mapper = new Mapper(config);
            return mapper.Map<AccountEntity, Account>(account);
        }
        public static IEnumerable<Account> ToDomain(this IEnumerable<AccountEntity> account)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AccountEntity, Account>()
                .ForMember("Role", opt => opt.MapFrom(src => src.Role))
                .ForMember("Customer", opt => opt.MapFrom(src => src.Customer)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<AccountEntity>, IEnumerable<Account>>(account);
        }
    }
}
