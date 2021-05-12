using DataLayer.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Services
{
    public class CustomerService : ICustomersService
    {
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(Customer domain)
        {
            domain.Code = GenerateCustomerCode();
            unitOfWork.Customer.Add(domain.ToEntity());
            unitOfWork.Save();
        }

        public IEnumerable<Customer> GetAll()
        {
            var adminId = unitOfWork.Customer.GetWithInclude(x => x.Account).SingleOrDefault(adm => adm.Account.Role == EntitiesDataLayer.Role.Admin).Id;
            if(adminId != null)
            {
              return  unitOfWork.Customer.GetAll().Where(customer => customer.Id != adminId).ToArray().ToDomain();
            }
            return unitOfWork.Customer.GetAll().ToDomain();
        }

        public Customer GetById(Guid id)
        {
            var customer = unitOfWork.Customer.GetBy(customer => customer.Id == id);
            return customer?.ToDomain();
        }

        public void Remove(Customer domain)
        {
            var customer = unitOfWork.Customer.GetBy(customer => customer.Id == domain.Id);
            if (customer != null)
            {
                unitOfWork.Customer.Remove(customer);
                unitOfWork.Save();
            }
        }

        public void Update(Customer domain)
        {
            unitOfWork.Customer.Update(domain.ToEntity());
            unitOfWork.Save();
        }

        private string GenerateCustomerCode()
        {
            string lastCode = unitOfWork.Customer.GetAll().LastOrDefault()?.Code;
            if (lastCode != null)
            {
                Regex regex = new Regex(@"^\d{4}");
                string resultMach = regex.Match(lastCode)?.Value;
                if (string.IsNullOrEmpty(resultMach))
                {
                    int value = Convert.ToInt32(resultMach) + 1;
                    return $"{value.ToString().PadLeft(4, '0')}-{DateTime.Now.Year}";
                }
            }
            return $"0001-{DateTime.Now.Year}";
        }

    }
}

