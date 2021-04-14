using EntitiesDataLayer;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories.Abstract
{
    // This interface is an extension to the product entity and contains
    // contract for specific methods intended only for this entity.
    public interface IProductRepository: IRepository<ProductEntity>
    {
        ProductEntity GetByCode(string code);
        void RemoveByCode(string code);
    }
}
