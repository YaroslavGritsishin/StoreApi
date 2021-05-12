using EntitiesDataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntitiesDataLayer
{
    public class AccountEntity: EntityBase 
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        [ForeignKey("CustomerId")]
        [Required]
        public CustomerEntity Customer { get; set; }

    }
    public enum Role
    {
        Admin,
        User
    }
}
