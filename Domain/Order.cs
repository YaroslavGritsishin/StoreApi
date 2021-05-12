using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string Status { get; set; }
        public int OrderNumber { get; set; }
        public ICollection<OrderElement> OrderElements { get; set; }
        public Order()
        {
            OrderElements = new List<OrderElement>();
        }
    }
}
