using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Order
    {
        public Order()
        {
            Admin = new HashSet<Admin>();
            Pizza = new HashSet<Pizza>();
        }

        public int IdOrder { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeOrdered { get; set; }
        public TimeSpan TimeDelivered { get; set; }
        public int OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int DeliveryManIdDeliveryMan { get; set; }
        public int CustomerIdCustomer { get; set; }

        public virtual Customer CustomerIdCustomerNavigation { get; set; }
        public virtual DeliveryMan DeliveryManIdDeliveryManNavigation { get; set; }
        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
