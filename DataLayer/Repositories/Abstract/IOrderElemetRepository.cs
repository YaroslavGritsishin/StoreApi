using EntitiesDataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories.Abstract
{  
    // This interface is an extension for the entity of the order item and contains
    // contract for specific methods intended only for this entity.
    // Although I'm not going to do anything that is outside the scope of the IRepository contract
    // I added this feature
    public interface IOrderElemetRepository: IRepository<OrderElementEntity> 
    {

    }
}
