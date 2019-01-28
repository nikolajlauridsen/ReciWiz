using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecipeLib.Model;

namespace RecipeLib.Domain
{
    public class Recipe : IRecipe
    {
        public string Title { get; }
        public string Instructions { get; }
        public int ID { get; }

        public List<IingredientLine> Ingredients { get; private set; }
        
        public Recipe(string name, string instructions, List<IingredientLine> ingredients, int id)
        {
            Ingredients = ingredients;
            Title = name;
            Instructions = instructions;
            ID = id;
        }

        public void AddIngredient(IngredientLine ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public Dictionary<string, object> GetContext()
        {
            Dictionary<string, object> context = new Dictionary<string, object>();
            context["name"] = Title;
            context["id"] = ID;
            context["instructions"] = Instructions;
            context["ingredients"] = new List<Dictionary<string, object>>();
            foreach (IngredientLine ingredient in Ingredients) {
                ((List<Dictionary<string, object>>)context["ingredients"]).Add(ingredient.GetContext());
            }
            return context;
        }

    }
}
