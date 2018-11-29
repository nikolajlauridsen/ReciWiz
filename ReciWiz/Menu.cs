using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciWiz
{
    class Menu
    {
        private Controller Control = new Controller();

        public void Run()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create recipe\n2. View Recipe\n3. Test db");
                Console.Write("Input: ");
                string uinput = Console.ReadLine();
                switch (uinput)
                {
                    case "1":
                        Control.CreateNewRecipe();
                        break;
                    case "2":
                        Control.ShowRecipe();
                        break;
                    case "3":
                        Control.test();
                        break;
                    default:
                        menuRunning = false;
                        break;
                }
            }
        }

    }
}
