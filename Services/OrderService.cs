using DataLayer.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(Order domain)
        {
            unitOfWork.Order.Add(domain.ToEntity());
            unitOfWork.Save();

        }
        public IEnumerable<Order> GetAll()
        {
            return unitOfWork.Order.GetAll().ToDomain();
        }

        public IEnumerable<Order> GetAllByCustomerId(Guid customerId)
        {
            return unitOfWork.Order.GetAll().Where(customer => customer.Id == customerId).ToDomain();
        }

        public Order GetById(Guid id)
        {
            return unitOfWork.Order.GetBy(order => order.Id == id).ToDomain();
        }

        public void Remove(Order domain)
        {
            var result = unitOfWork.Order.GetBy(order => order.Id == domain.Id);
            if (result != null)
            {
                unitOfWork.Order.Remove(result);
                unitOfWork.Save();
            }
        }
        public void Update(Order domain)
        {
            unitOfWork.Order.Update(domain.ToEntity());
            unitOfWork.Save();
        }
    }
}

