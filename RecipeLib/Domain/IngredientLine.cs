using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecipeLib.Model;

namespace RecipeLib.Domain
{
    public class IngredientLine : IingredientLine 
    {
        public Iingredient Ingredient { get; }
        public double Quantity { get; }
        public string Unit { get; }

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
            context["id"] = this.Ingredient.ID; 
            context["quantity"] = Quantity;
            context["unit"] = Unit;

            return context;
        }
    }
}
