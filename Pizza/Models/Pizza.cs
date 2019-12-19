using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            IngredientSet = new HashSet<IngredientSet>();
        }

        public int IdPizza { get; set; }
        public string Name { get; set; }
        public bool IsCustomizable { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public decimal Discount { get; set; }
        public int BreadTypeIdBreadType { get; set; }
        public int? OrderIdOrder { get; set; }
        public bool IsVege { get; set; }
        public bool IsSpicy { get; set; }

        public virtual BreadType BreadTypeIdBreadTypeNavigation { get; set; }
        public virtual Order OrderIdOrderNavigation { get; set; }
        public virtual ICollection<IngredientSet> IngredientSet { get; set; }
    }
}
