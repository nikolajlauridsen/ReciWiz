using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciLib
{
    public class Cookbook
    {
        public string Name;
        private readonly List<Recipe> Recipies = new List<Recipe>();

        public Cookbook(string name)
        {
            Name = name;
        }

        public Recipe GetRecipe(string name)
        {
            foreach(Recipe recipe in Recipies)
            {
                if(name == recipe.Name)
                {
                    return recipe;
                }
            }
            return null;
        }

        public void CreateRecipe(string name, List<Ingredient> ingredients, string instructions)
        {
            Recipe recipe = new Recipe(name, instructions, ingredients);
            Recipies.Add(recipe);
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipies.Add(recipe);
        }
    }
}
