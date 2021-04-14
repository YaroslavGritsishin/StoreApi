using DataLayer.Repositories.Abstract;
using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        private readonly DbContext context;
        public ProductRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        public ProductEntity GetByCode(string code)
        {
            return context.Set<ProductEntity>().Find(code);
        }

        public void RemoveByCode(string code)
        {
            var result = context.Set<ProductEntity>().Find(code);
            if (result != null)
                context.Set<ProductEntity>().Remove(result);
        }
    }
}
