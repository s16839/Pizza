using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class BreadType
    {
        public BreadType()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdBreadType { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
