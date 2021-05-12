using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IOrderService : IService<Order>
    {
        IEnumerable<Order> GetAllByCustomerId(Guid customerId);

    }
}
