using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReciLib;

namespace ReciWiz
{
    class Controller
    {
        private CookbookRepo Repo = new CookbookRepo();

        public Controller()
        {
            Repo.CreateCookBook("Test");
        }

        public void CreateNewRecipe()
        {
            Console.Clear();
            Console.Write("Cookbook name: ");
            Cookbook book = Repo.GetBook(Console.ReadLine());
            if (book is null)
            {
                Console.WriteLine("Book does not exist");
                return;
            }

            // Get recipe name
            Console.Write("Recipe name: ");
            string name = Console.ReadLine();
            
            // Get ingredients
            List<Ingredient> ingredientList = new List<Ingredient>();
            bool takeIngredient = true;
            while (takeIngredient)
            {
                Console.Write("Ingredient (quantity unit name): ");
                string uInput = Console.ReadLine();
                if(uInput.Length == 0)
                {
                    takeIngredient = false;
                    break;
                }

                string[] split = uInput.Split(' ');
                Ingredient ingredient = new Ingredient(split[2], split[1], double.Parse(split[0]));
                ingredientList.Add(ingredient);
            }

            // Get instructions
            Console.WriteLine("Description: ");
            string instructions = Console.ReadLine();

            // Create recipe
            Recipe recipe = new Recipe(name, instructions, ingredientList);
            book.AddRecipe(recipe);
            Console.WriteLine("Recipe added");
        }

        public void ShowRecipe()
        {
            Console.Clear();
            Console.Write("Cookbook: ");
            Cookbook book = Repo.GetBook(Console.ReadLine());
            Console.Write("Recipe name: ");
            Recipe recipe = book.GetRecipe(Console.ReadLine());
            Console.Clear();

            if (book != null)
            {
                Console.WriteLine(recipe.Name);
                Console.WriteLine("\nIngredients:");
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine(String.Format("{0} {1} {2}", ingredient.Quantity, ingredient.Unit, ingredient.Name));
                }
                Console.WriteLine(recipe.Instructions);
            } else
            {
                Console.WriteLine("Book does not exist");
            }
            Console.ReadKey(false);
        }
    }
}
