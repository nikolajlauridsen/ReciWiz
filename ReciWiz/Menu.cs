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
        private Controller control = Controller();
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

            List<Dictionary<string, object>> ingredients = (List<Dictionary<string, object>>)data["ingredients"];
            foreach(Dictionary<string, object> ingredient in ingredients) {
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
            List<Dictionary<string, object>> ingredients = new List<Dictionary<string, object>>();
            bool takeIngredient = true;
            while (takeIngredient) {
                Console.Write("Ingredient (quantity unit name): ");
                string uInput = Console.ReadLine();
                if (uInput.Length == 0) {
                    takeIngredient = false;
                    break;
                }

                string[] split = uInput.Split(' ');
                Dictionary<string, object> context = new Dictionary<string, object>();
                context["quantity"] = Double.Parse(split[0]);
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
            Console.Write("Author name: ");
            string author = Console.ReadLine();
            control.CreateCookbook(name, author);
        }

        public void ShowBook()
        {
            List<Dictionary<string, object>> books = control.GetBooks();

            Console.WriteLine("Available books: ");
            foreach(Dictionary<string, object> book in books) {
                Console.WriteLine($"\t{book["name"]}");
            }
        }
    }
}
