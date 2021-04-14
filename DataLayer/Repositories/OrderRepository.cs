using DataLayer.Repositories.Abstract;
using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
        private readonly DbContext context;
        public OrderRepository(DbContext context):base(context)
        {
            this.context = context;
        }
       
    }
}
