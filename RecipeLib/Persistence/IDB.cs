using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Persistence
{
    public interface IDB
    {
        Dictionary<string, object> GetAllIngredients();

        Dictionary<string, object> GetIngredients(int recipeID);

        Dictionary<string, object> GetCookBooks();

        Dictionary<string, object> GetRecipies(string cookbookName);

        // Returns their ID
        int CreateIngredient(string name);

        int CreateCookbook(string name);

        int CreateRecipe(string cookbookName, string recipeName,
            List<Dictionary<string, string>> ingredientsData, string instructions);
    }
}
