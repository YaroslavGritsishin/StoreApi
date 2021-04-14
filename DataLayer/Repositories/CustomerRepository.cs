using DataLayer.Repositories.Abstract;
using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRepository
    {
        private readonly DbContext context;
        public CustomerRepository(DbContext context) : base(context) 
        {
            this.context = context;
        }
       
        public CustomerEntity GetByCode(string code)
        {
            return context.Set<CustomerEntity>().SingleOrDefault(customer => customer.Code == code);
        }

        public void RemoveByCode(string code)
        {
            var result = context.Set<CustomerEntity>().SingleOrDefault(customer => customer.Code == code);
            if (result != null)
            {
                context.Set<CustomerEntity>().Remove(result);
            }
        }

    }
}
