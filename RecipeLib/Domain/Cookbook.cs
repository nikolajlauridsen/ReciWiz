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

        private readonly List<Recipe> Recipies = new List<Recipe>();

        public Cookbook(string name, string author, int id)
        {
            Title = name;
            Author = author;
            ID = id;

            foreach (Dictionary<string, object> recipeData in db.GetRecipies(id)) {
                List<IingredientLine> ingredients = createIngredientLinesObjects(((List<Dictionary<string, object>>)recipeData["ingredients"]));
                Recipe recipe = new Recipe((string)recipeData["name"], (string)recipeData["directions"], ingredients, (int)recipeData["id"]);
                Recipies.Add(recipe);
            }
        }

        public Recipe GetRecipe(string name)
        {
            foreach(Recipe recipe in Recipies)
            {
                if(name.Equals(recipe.Title))
                {
                    return recipe;
                }
            }
            return null;
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

        public void AddRecipe(Recipe recipe)
        {
            Recipies.Add(recipe);
        }

        private List<IingredientLine> createIngredientLinesObjects(List<Dictionary<string, object>> ingredientsData)
        {
            List<IingredientLine> ingredients = new List<IingredientLine>();
            foreach (Dictionary<string, object> ingredientData in ingredientsData) {
                Ingredient ingredient = ingredientRepo.GetIngredient((string)ingredientData["name"]);
                ingredients.Add(new IngredientLine(ingredient, (double)ingredientData["quantity"], (string)ingredientData["unit"]));
            }
            return ingredients;
        }
    }
}
