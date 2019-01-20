using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Persistence
{
    public interface IDB
    {
        Dictionary<string, object> GetIngredients();

        Dictionary<string, object> GetCookBooks();

        Dictionary<string, object> GetRecipies(string cookbookName);

        void CreateIngredient(string name);

        void CreateCookbook(string name);

        void CreateRecipe(string cookbookName, string recipeName,
            List<Dictionary<string, string>> ingredientsData, string instructions);
    }
}
