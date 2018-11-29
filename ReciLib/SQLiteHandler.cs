using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciLib
{
    public class SQLiteHandler : IDB
    {
        private string ConnectionString;

        public SQLiteHandler(string path)
        {
            ConnectionString = path;
        }

        public void SaveRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> LoadRecipies()
        {
            throw new NotImplementedException();
        }
    }
}
