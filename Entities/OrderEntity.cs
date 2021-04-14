using EntitiesDataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesDataLayer
{
    public class OrderEntity : EntityBase
    {
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderNumber { get; set; }
        public string Status { get; set; }
        public OrderEntity()
        {
            OrderElements = new List<OrderElementEntity>();
        }
        
        // Binding map one to many for EF (From Customer to Orders)
        public Guid CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        // Binding map many to many for EF (From Orders to OrderElemnts)
        public ICollection<OrderElementEntity> OrderElements { get; set; }

    }
}
