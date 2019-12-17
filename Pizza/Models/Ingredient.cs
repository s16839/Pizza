using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientSet = new HashSet<IngredientSet>();
        }

        public int IdIngredient { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<IngredientSet> IngredientSet { get; set; }
    }
}
