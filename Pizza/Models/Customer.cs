using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int IdCustomer { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
