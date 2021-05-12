using DataLayer.Repositories.Abstract;
using EntitiesDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class AccountRepository : Repository<AccountEntity>, IAccountRepository
    {
        private readonly DbContext context;
        public AccountRepository(DbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
