using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
   public interface IOrderElementService: IService<OrderElement>
    {
        void AddRange(IEnumerable<OrderElement> elements);
    }
}
