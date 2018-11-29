using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciLib
{
    interface IDB
    {
        void SaveRecipe(Recipe recipe);
        List<Recipe> LoadRecipies();
    }
}
