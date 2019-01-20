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

		internal Dictionary<string, string> GetContext()
        {
            Dictionary<string, string> context = new Dictionary<string, string>();
            context["name"] = this.Ingredient.Name;
            context["quantity"] = Quantity.ToString(); ;
            context["unit"] = Unit;

            return context;
        }
    }
}
