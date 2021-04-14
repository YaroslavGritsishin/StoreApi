using EntitiesDataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiesDataLayer
{
    public class OrderElementEntity : EntityBase
    {
        public int ItemCount { get; set; }
        public double ItemPrice { get; set; }
        public Guid OrderId { get; set; }

        public OrderElementEntity()
        {
            Orders = new List<OrderEntity>();
        }
        // Binding map many to many for EF (From Orders to OrderElemnts)
        public ICollection<OrderEntity> Orders { get; set; }
        // Binding map one to many for EF (From Produt to OrderElemnts)
        [ForeignKey("Product")]
        public Guid ItemId { get; set; }
        public ProductEntity Product { get; set; }

    }
}
