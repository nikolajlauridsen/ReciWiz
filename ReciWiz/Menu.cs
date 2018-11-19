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
            Control.CreateNewRecipe();
        }
    }
}
