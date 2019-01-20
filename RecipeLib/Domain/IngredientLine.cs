using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Domain
{
    public class IngredientLine
    {
        public Ingredient Ingredient;
        public double Quantity;
        public string Unit;

		public IngredientLine(Ingredient ingredient,double quantity, string unit)
        {
            Ingredient = ingredient;
            Quantity = quantity;
            Unit = unit;
        }

		internal Dictionary<string, object> GetContext()
        {
            Dictionary<string, object> context = new Dictionary<string, object>();
            context["name"] = this.Ingredient.Name;
            context["quantity"] = Quantity;
            context["unit"] = Unit;

            return context;
        }
    }
}
