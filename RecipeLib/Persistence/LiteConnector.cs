using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace RecipeLib.Persistence
{
    public class LiteConnector : IDB
    {
        private string ConnectionString;
        SQLiteConnection conn;

        public LiteConnector()
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = "recipe.sqlite";
            builder.ForeignKeys = true;
            ConnectionString = builder.ToString();
            conn = new SQLiteConnection(ConnectionString);
        }

        public int CreateCookbook(string name)
        {
            throw new NotImplementedException();
        }

        public int CreateIngredient(string name)
        {
            throw new NotImplementedException();
        }

        public int CreateRecipe(string cookbookName, string recipeName, List<Dictionary<string, string>> ingredientsData, string instructions)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetCookBooks()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetIngredients(int recipeID)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetRecipies(string cookbookName)
        {
            throw new NotImplementedException();
        }
    }
}
