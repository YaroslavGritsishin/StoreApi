using EntitiesDataLayer;
using System.Collections.Generic;

namespace DataLayer.Repositories.Abstract
{   
    // This interface is an extension to the customer entity and contains
    // contract for specific methods intended only for this entity.
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        CustomerEntity GetByCode(string code);
        void RemoveByCode(string code);
    }
}
