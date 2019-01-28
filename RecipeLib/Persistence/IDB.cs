using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecipeLib.Model;

namespace RecipeLib.Persistence
{
    public interface IDB
    {
        List<Dictionary<string, object>> GetAllIngredients();

        List<Dictionary<string, object>> GetIngredients(int recipeID);

        List<Dictionary<string, object>> GetCookBooks();

        List<Dictionary<string, object>> GetRecipies(int cookBookID);

        // Returns their ID
        int CreateIngredient(string name);

        int CreateCookbook(string name, string author);

        int CreateRecipe(int cookBookId, string recipeName,
            List<IingredientLine> ingredientsData, string instructions);
    }
}
