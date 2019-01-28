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

        public Recipe(string name, string instructions, int id) : this(name, instructions, new List<IingredientLine>(), id)
        {
            
        }

        public void AddIngredient(IngredientLine ingredient)
        {
            Ingredients.Add(ingredient);
        }

    }
}
