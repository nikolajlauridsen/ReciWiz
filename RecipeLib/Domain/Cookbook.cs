using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Domain
{
    public class Cookbook
    {
        public string Name;
        private IngredientRepo ingredientRepo = new IngredientRepo();

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

        public Dictionary<string, object> GetRecipeData(string recipeName)
        {
            
            Recipe recipe = GetRecipe(recipeName);
            return recipe.GetRecipeData() ;
        }

        public void CreateRecipe(string name, List<Dictionary<string, string>> ingredientsData, string instructions)
        {
            // Create ingredient lines
            List<IngredientLine> ingredients = new List<IngredientLine>();
            foreach (Dictionary<string, string> ingredientData in ingredientsData) {
                Ingredient ingredient = ingredientRepo.GetIngredient(ingredientData["name"]);
                ingredients.Add(new IngredientLine(ingredient, double.Parse(ingredientData["quantity"]), ingredientData["unit"]));
            }

            Recipe recipe = new Recipe(name, instructions, ingredients);
            Recipies.Add(recipe);
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipies.Add(recipe);
        }
    }
}
