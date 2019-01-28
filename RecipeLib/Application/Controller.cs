using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecipeLib.Domain;
using RecipeLib.Model;

namespace RecipeLib.Application
{
    public class Controller
    {
        private static Controller instance;
        IngredientRepo ingredientRepo;
        CookbookRepo bookRepo;

        private Controller()
        {
            ingredientRepo = new IngredientRepo();
            bookRepo = new CookbookRepo();
        }

        public static Controller GetInstance()
        {
            if(instance == null) {
                instance = new Controller();
            }
            return instance;
        }

        // Create
        public void CreateRecipe(string cookbookname, string name, List<Dictionary<string, object>> ingredientsData, string instructctions) {
            bookRepo.GetBook(cookbookname).CreateRecipe(name, ingredientsData, instructctions);
        }

        public void CreateRecipe(int cookbookID, string name, List<Dictionary<string, object>> ingredientsData, string instructctions)
        {
            bookRepo.GetBook(cookbookID).CreateRecipe(name, ingredientsData, instructctions);
        }

        public void CreateCookbook(string name, string author)
        {
            bookRepo.CreateCookBook(name, author);
        }

        // Read
        public IRecipe GetRecipe(string cookbookname, string recipeName)
        {
            return bookRepo.GetBook(cookbookname).GetRecipe(recipeName);
        }

        public IRecipe GetRecipe(int bookID, int recipeID)
        {
            return bookRepo.GetBook(bookID).GetRecipe(recipeID);
        }

        public List<ICookbook> GetBooks()
        {
            return bookRepo.GetBooks();
        }

        public List<IRecipe> GetRecipies(int bookID)
        {
            return bookRepo.GetBook(bookID).GetRecipes();
        }
    }
}
