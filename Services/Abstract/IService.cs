using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IService<TDomain> where TDomain : class
    {
        void Add(TDomain domain);
        void Remove(TDomain domain);
        TDomain GetById(Guid id);
        IEnumerable<TDomain> GetAll();
        void Update(TDomain domain);
    }
}
