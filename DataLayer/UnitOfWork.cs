using DataLayer.Repositories;
using DataLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context appContext;
        private ICustomerRepository customerRepository;
        private IOrderRepository orderRepository;
        private IOrderElemetRepository orderElemetRepository;
        private IProductRepository productRepository;
        private IAccountRepository accountRepository;
        public UnitOfWork(Context appContext)
        {
            this.appContext = appContext;
        }
        public IAccountRepository Account
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(appContext);
                return accountRepository;
            }
        }
        public ICustomerRepository Customer
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(appContext);
                return customerRepository;
            }
        }
        public IOrderRepository Order 
        {
            get 
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(appContext);
                return orderRepository;

            }
        }
        public IOrderElemetRepository OrderElemet 
        {
            get 
            {
                if(orderElemetRepository == null)
                    orderElemetRepository = new OrderElementRepository(appContext);
                return orderElemetRepository;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(appContext);
                return productRepository;
            }
        }
        public void Save()
        {
            appContext.SaveChanges();
        }
        
    }
}
