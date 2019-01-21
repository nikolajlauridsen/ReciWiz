using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLib.Domain;

namespace RecipeLib.Application
{
    public class Controller
    {
        IngredientRepo ingredientRepo = new IngredientRepo();
        CookbookRepo bookRepo = new CookbookRepo();

        // Create
        public void CreateRecipe(string cookbookname, string name, List<Dictionary<string, object>> ingredientsData, string instructctions) {
            bookRepo.GetBook(cookbookname).CreateRecipe(name, ingredientsData, instructctions);
        }

        public void CreateCookbook(string name, string author)
        {
            bookRepo.CreateCookBook(name, author);
        }

        // Read
        public Dictionary<string, object> GetRecipe(string cookbookname, string recipeName)
        {
            return bookRepo.GetBook(cookbookname).GetRecipeData(recipeName);
        }

        public List<Dictionary<string, object>> GetBooks()
        {
            return bookRepo.GetBooksData();
        }
    }
}
