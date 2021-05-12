using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        IOrderElemetRepository OrderElemet { get; }
        IProductRepository Product { get; }
        IAccountRepository Account { get; }
        void Save();

    }
}
