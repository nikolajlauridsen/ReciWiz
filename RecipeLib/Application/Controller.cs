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
        public void CreateRecipe(int cookbookID, string name, List<IingredientLine> ingredients, string instructctions)
        {
            bookRepo.GetBook(cookbookID).CreateRecipe(name, ingredients, instructctions);
        }

        public void CreateCookbook(string name, string author)
        {
            bookRepo.CreateCookBook(name, author);
        }

        public IingredientLine CreateIngredientLine(string name, double quantity, string unit) {
            return ingredientRepo.CreateIngredientLine(name, quantity, unit);
        }

        // Read
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

        // Delete
        public void DeleteBook(int bookID)
        {
            bookRepo.DeleteCookBook(bookID);
        }
    }
}
