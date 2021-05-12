using DataLayer.Repositories.Abstract;
using Domain;
using Mappers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(Account domain)
        {
            unitOfWork.Account.Add(domain.ToEntity());
            unitOfWork.Save();
        }

        public string GenerateJWT(Account account, IOptions<AuthOptions> options)
        {
            var authParams = options.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new Claim("role", account.Role.ToString())
            };

            var token = new JwtSecurityToken(
                authParams.Issure,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Account Get(string email, string pwd)
        {
            return unitOfWork.Account.GetBy(acc => acc.Email == email && acc.Password == pwd).ToDomain();
        }

        public IEnumerable<Account> GetAll()
        {
          return unitOfWork.Account.GetAll().ToDomain();
        }

        public Account GetById(Guid id)
        {
            return unitOfWork.Account.GetBy(acc => acc.Id == id).ToDomain();
        }

        public void Remove(Account domain)
        {
            var result = unitOfWork.Account.GetBy(acc => acc.Id == domain.Id);
            if (result != null)
            {
                unitOfWork.Account.Remove(result);
                unitOfWork.Save();
            }

        }
        public void Update(Account domain)
        {
            unitOfWork.Account.Update(domain.ToEntity());
            unitOfWork.Save();
        }
    }
}
