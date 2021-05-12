using Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstract
{
    public interface IAccountService: IService<Account>
    {
        Account Get(string email, string pwd);
        string GenerateJWT(Account account, IOptions<AuthOptions> options);
    }
}
