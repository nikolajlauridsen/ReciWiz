using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLib.Persistence;
using RecipeLib.Model;

namespace RecipeLib.Domain
{
    public class Cookbook : ICookbook
    {

        public string Title { get; }
        public string Author { get; }
        public int ID { get; }

        private IDB db = new LiteConnector();

        private IngredientRepo ingredientRepo = new IngredientRepo();

        private readonly List<IRecipe> Recipies = new List<IRecipe>();

        public Cookbook(string name, string author, int id)
        {
            Title = name;
            Author = author;
            ID = id;
            Recipies = db.GetRecipies(id);
        }

        public Recipe GetRecipe(int id)
        {
            foreach (Recipe recipe in Recipies) {
                if (id == recipe.ID) {
                    return recipe;
                }
            }
            return null;
        }

        public List<IRecipe> GetRecipes()
        {
            List<IRecipe> recipies = new List<IRecipe>();
            foreach(IRecipe recipe in Recipies) {
                recipies.Add(recipe);
            }
            return recipies;
        }

        public void CreateRecipe(string name, List<IingredientLine> ingredientsData, string instructions)
        {

            int recipeID = db.CreateRecipe(ID, name, ingredientsData, instructions);
            Recipe recipe = new Recipe(name, instructions, ingredientsData, recipeID);
            Recipies.Add(recipe);
        }

        private void AddRecipe(Recipe recipe)
        {
            Recipies.Add(recipe);
        }

        public void DeleteRecipe(int recipeID)
        {
            Recipe reci = GetRecipe(recipeID);
            db.DeleteRecipe(recipeID);
            Recipies.Remove(reci);

        }
    }
}
