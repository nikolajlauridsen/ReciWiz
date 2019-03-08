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

        private readonly List<IRecipe> _recipes;

        public Cookbook(string name, string author, int id)
        {
            Title = name;
            Author = author;
            ID = id;
            _recipes = db.GetRecipies(id);
        }

        public Recipe GetRecipe(int id)
        {
            foreach (Recipe recipe in _recipes) {
                if (id == recipe.ID) {
                    return recipe;
                }
            }
            return null;
        }

        public List<IRecipe> GetRecipes()
        {
            List<IRecipe> recipies = new List<IRecipe>();
            foreach(IRecipe recipe in _recipes) {
                recipies.Add(recipe);
            }
            return recipies;
        }

        public void CreateRecipe(string name, List<IingredientLine> ingredientsData, string instructions)
        {

            int recipeID = db.CreateRecipe(ID, name, ingredientsData, instructions);
            Recipe recipe = new Recipe(name, instructions, ingredientsData, recipeID);
            _recipes.Add(recipe);
        }

        private void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public void DeleteRecipe(int recipeID)
        {
            Recipe reci = GetRecipe(recipeID);
            db.DeleteRecipe(recipeID);
            _recipes.Remove(reci);

        }
    }
}
