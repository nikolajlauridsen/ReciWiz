using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ReciLib
{
    public class SQLiteHandler : IDB
    {
        private string ConnectionString;
        SQLiteConnection conn;

        public SQLiteHandler(string path)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            path = "recipe.sqlite";
            builder.DataSource = path;
            builder.ForeignKeys = true;
            ConnectionString = builder.ToString();
            conn = new SQLiteConnection(ConnectionString);

            conn.Open();
            string qry = @"INSERT INTO RECIPE VALUES ('Pandekager', 'Bland og steg')";

            SQLiteCommand cmd = new SQLiteCommand(qry, conn);
            conn.Close();
            
            
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
