using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderElement
    {
        public Guid Id { get; set; }
        public Guid OderId{ get; set; }
        public int ItemCount { get; set; }
        public double ItemPrice { get; set; }
        public Product Product { get; set; }
    }
}
