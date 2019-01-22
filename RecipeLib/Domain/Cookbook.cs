using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLib.Persistence;

namespace RecipeLib.Domain
{
    public class Cookbook
    {
        public string Title;
        public string Author;
        public int ID;
        private IDB db = new LiteConnector();

        private IngredientRepo ingredientRepo = new IngredientRepo();

        private readonly List<Recipe> Recipies = new List<Recipe>();

        public Cookbook(string name, string author, int id)
        {
            Title = name;
            Author = author;
            ID = id;

            foreach (Dictionary<string, object> recipeData in db.GetRecipies(id)) {
                List<IngredientLine> ingredients = createIngredientLinesObjects(((List<Dictionary<string, object>>)recipeData["ingredients"]));
                Recipe recipe = new Recipe((string)recipeData["name"], (string)recipeData["directions"], ingredients, (int)recipeData["id"]);
                Recipies.Add(recipe);
            }
        }

        public Recipe GetRecipe(string name)
        {
            foreach(Recipe recipe in Recipies)
            {
                if(name.Equals(recipe.Name))
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

        public Dictionary<string, object> GetRecipeData(string recipeName)
        {
            
            Recipe recipe = GetRecipe(recipeName);
            return recipe.GetContext() ;
        }

        public Dictionary<string, object> GetRecipeData(int recipeID)
        {
            return GetRecipe(recipeID).GetContext();
        }

        public void CreateRecipe(string name, List<Dictionary<string, object>> ingredientsData, string instructions)
        {
            // Create ingredient lines
            List<IngredientLine> ingredients = createIngredientLinesObjects(ingredientsData);
            ingredientsData = new List<Dictionary<string, object>>();
            foreach(IngredientLine ingredient in ingredients) {
                ingredientsData.Add(ingredient.GetContext());
            }

            int recipeID = db.CreateRecipe(ID, name, ingredientsData, instructions);
            Recipe recipe = new Recipe(name, instructions, ingredients, recipeID);
            Recipies.Add(recipe);
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipies.Add(recipe);
        }

        public Dictionary<string, object> GetContext()
        {
            Dictionary<string, object> context = new Dictionary<string, object>();

            context["name"] = Title;
            context["author"] = Author;
            context["id"] = ID;

            return context;
        }

        public List<Dictionary<string, object>> GetRecipeOverview()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach(Recipe recipe in Recipies) {
                Dictionary<string, object> context = new Dictionary<string, object>();

                context["name"] = recipe.Name;
                context["id"] = recipe.ID;
                data.Add(context);
            }
            

            return data;
        }

        private List<IngredientLine> createIngredientLinesObjects(List<Dictionary<string, object>> ingredientsData)
        {
            List<IngredientLine> ingredients = new List<IngredientLine>();
            foreach (Dictionary<string, object> ingredientData in ingredientsData) {
                Ingredient ingredient = ingredientRepo.GetIngredient((string)ingredientData["name"]);
                ingredients.Add(new IngredientLine(ingredient, (double)ingredientData["quantity"], (string)ingredientData["unit"]));
            }
            return ingredients;
        }
    }
}
