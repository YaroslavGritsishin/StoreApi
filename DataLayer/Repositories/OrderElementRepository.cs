using DataLayer.Repositories.Abstract;
using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class OrderElementRepository: Repository<OrderElementEntity>, IOrderElemetRepository
    {
        private readonly DbContext context;
        public OrderElementRepository(DbContext context): base(context)
        {
            this.context = context;
        }

    }
}
