using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLib.Application;
using SmartMenuLibrary;

namespace ReciWiz
{
    class Menu
    {
        private Controller control = new Controller();
        private SmartMenu menu;

        public Menu()
        {
            Bindings binds = new Bindings();

            binds.Bind("crecipe", CreateRecipe);
            binds.Bind("srecipe", ShowRecipe);
            binds.Bind("cbook", CreateBook);
            binds.Bind("sbook", ShowBook);

            menu = new SmartMenu(binds);
            menu.LoadMenu("menu.txt");
        }

        public void Run()
        {
            menu.Activate();
        }

        public void ShowRecipe()
        {
            string bookName, reciName;

            // Prompt user
            Console.Write("\nCookbook name: ");
            bookName = Console.ReadLine();
            Console.Write("Recipe name: ");
            reciName = Console.ReadLine();
            
            //Get data
            Dictionary<string, object> data = control.GetRecipe(bookName, reciName);

            // Print head
            Console.WriteLine("\n" + (string)data["name"] + "\n");
            Console.WriteLine("Ingredients");

            List<Dictionary<string, string>> ingredients = (List<Dictionary<string, string>>)data["ingredients"];
            foreach(Dictionary<string, string> ingredient in ingredients) {
                Console.WriteLine($"\t{ingredient["quantity"]} {ingredient["unit"]} {ingredient["name"]}");
            }

            // Print instructions
            Console.WriteLine("\nInstructions: ");
            Console.WriteLine((string)data["instructions"]);
        }

        public void CreateRecipe()
        {
            string bookName, reciName, instructions;

            // Take cookbook name
            Console.Write("Cookbook name: ");
            bookName = Console.ReadLine();

            // Take recipe name
            Console.Write("Recipe name: ");
            reciName = Console.ReadLine();

            // Take ingredients
            List<Dictionary<string, string>> ingredients = new List<Dictionary<string, string>>();
            bool takeIngredient = true;
            while (takeIngredient) {
                Console.Write("Ingredient (quantity unit name): ");
                string uInput = Console.ReadLine();
                if (uInput.Length == 0) {
                    takeIngredient = false;
                    break;
                }

                string[] split = uInput.Split(' ');
                Dictionary<string, string> context = new Dictionary<string, string>();
                context["quantity"] = split[0];
                context["unit"] = split[1];
                context["name"] = split[2];
                ingredients.Add(context);
            }

            // Take instructions
            Console.WriteLine("Instructions: ");
            instructions = Console.ReadLine();

            control.CreateRecipe(bookName, reciName, ingredients, instructions);
        }

        public void CreateBook()
        {
            Console.Write("Book name: ");
            string name = Console.ReadLine();
            control.CreateCookbook(name);
        }

        public void ShowBook()
        {
            List<string> bookNames = control.GetBooks();

            Console.WriteLine("Available books: ");
            foreach(string bookName in bookNames) {
                Console.WriteLine($"\t{bookName}");
            }
        }
    }
}
