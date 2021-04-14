using EntitiesDataLayer.Abstract;
using System;
using System.Collections.Generic;

namespace EntitiesDataLayer
{
    public class ProductEntity: EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public ProductEntity()
        {
            OrderElements = new List<OrderElementEntity>();
        }
        // Binding map one to many for EF (From Produt to OrderElemnts)
        public ICollection<OrderElementEntity> OrderElements { get; set; }
    }
}
