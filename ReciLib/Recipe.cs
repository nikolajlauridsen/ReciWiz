using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciLib
{
    class Recipe
    {
        public string Name;
        public string Instructions;

        public List<Ingredient> Ingredients { get; private set; }
        
        public Recipe(string name, string instructions, List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
            Name = name;
            Instructions = instructions;
        }

        public Recipe(string name, string instructions): this(name, instructions, null)
        {
            Ingredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

    }
}
