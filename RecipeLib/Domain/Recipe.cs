using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Domain
{
    public class Recipe
    {
        public string Name;
        public string Instructions;
        public int ID;

        public List<IngredientLine> Ingredients { get; private set; }
        
        public Recipe(string name, string instructions, List<IngredientLine> ingredients, int id)
        {
            Ingredients = ingredients;
            Name = name;
            Instructions = instructions;
            ID = id;
        }


        public Recipe(string name, string instructions): this(name, instructions, null, 0)
        {
            Ingredients = new List<IngredientLine>();
        }

        public void AddIngredient(IngredientLine ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public Dictionary<string, object> GetContext()
        {
            Dictionary<string, object> context = new Dictionary<string, object>();
            context["name"] = Name;
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
