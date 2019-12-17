using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Name { get; set; }
        public int OrderIdOrder { get; set; }

        public virtual Order OrderIdOrderNavigation { get; set; }
    }
}
