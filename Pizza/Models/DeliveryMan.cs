using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class DeliveryMan
    {
        public DeliveryMan()
        {
            Order = new HashSet<Order>();
        }

        public int IdDeliveryMan { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int EmpNumber { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
