using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntitiesDataLayer.Abstract
{
   public class EntityBase : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
