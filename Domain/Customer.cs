using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Account Account { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
