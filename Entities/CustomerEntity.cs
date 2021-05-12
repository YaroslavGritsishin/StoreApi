using EntitiesDataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiesDataLayer
{
    public class CustomerEntity : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int Discount { get; set; }

        // Binding map one to many for EF (From Customer to Orders)
        public CustomerEntity()
        {
            Orders = new List<OrderEntity>();
        }
        public ICollection<OrderEntity> Orders { get; set; }
        [Required]
        public AccountEntity Account { get; set; }

    }
}
