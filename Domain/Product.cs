using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid OrderElementId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }

    }
}
