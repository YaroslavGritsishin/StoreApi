using DataLayer.Repositories.Abstract;
using Domain;
using Mappers;
using Services.Abstract;
using System;
using System.Collections.Generic;

namespace Services
{
    public class OrderElementService : IOrderElementService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderElementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(OrderElement domain)
        {
            unitOfWork.OrderElemet.Add(domain.ToEntity());
            unitOfWork.Save();
        }

        public void AddRange(IEnumerable<OrderElement> elements)
        {
            unitOfWork.OrderElemet.AddRange(elements.ToEntity());
            unitOfWork.Save();
        }

        public IEnumerable<OrderElement> GetAll()
        {
            return unitOfWork.OrderElemet.GetAll().ToDomain();
        }

        public OrderElement GetById(Guid id)
        {
            return unitOfWork.OrderElemet.GetBy(orderElement => orderElement.Id == id).ToDomain();
        }

        public void Remove(OrderElement domain)
        {
            var result = unitOfWork.OrderElemet.GetBy(orderElement => orderElement.Id == domain.Id);
            if (result != null)
            {
                unitOfWork.OrderElemet.Remove(result);
                unitOfWork.Save();
            }
        }

        public void Update(OrderElement domain)
        {
            unitOfWork.OrderElemet.Update(domain.ToEntity());
            unitOfWork.Save();
        }
    }
}
