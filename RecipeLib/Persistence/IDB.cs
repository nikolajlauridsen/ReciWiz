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
        List<Iingredient> GetAllIngredients();

        List<IingredientLine> GetIngredients(int recipeID);

        List<ICookbook> GetCookBooks();

        List<IRecipe> GetRecipies(int cookBookID);

        // Returns their ID
        int CreateIngredient(string name);

        int CreateCookbook(string name, string author);

        int CreateRecipe(int cookBookId, string recipeName,
            List<IingredientLine> ingredientsData, string instructions);

        // Delete 
        void DeleteCookbook(int cookbookID);

        void DeleteRecipe(int recipeID);
    }
}
