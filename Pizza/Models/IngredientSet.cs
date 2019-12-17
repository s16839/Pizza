using System;
using System.Collections.Generic;

namespace Pizza.Models
{
    public partial class IngredientSet
    {
        public int PizzaIdPizza { get; set; }
        public int IngredientIdIngredient { get; set; }

        public virtual Ingredient IngredientIdIngredientNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
    }
}
