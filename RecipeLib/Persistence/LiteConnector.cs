using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

using RecipeLib.Model;

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

        public int CreateCookbook(string name, string author)
        {
            int rowId;
            conn.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
                cmd.CommandText = @"INSERT INTO COOKBOOK (Title, Author, ID) VALUES (@name, @author, null);";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@name", name));
                cmd.Parameters.Add(new SQLiteParameter("@author", author));
                cmd.ExecuteNonQuery();
            }

            // Get ID
            rowId = Convert.ToInt32(conn.LastInsertRowId);
            conn.Close();

            return rowId;
        }

        public int CreateIngredient(string name)
        {
            int rowId;
            conn.Open();
            // Insert ingredient
            using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
                cmd.CommandText = @"INSERT INTO INGREDIENT (Name, ID) VALUES(@name, null)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@name", name));
                cmd.ExecuteNonQuery();
            }

            // Get ID
            rowId = Convert.ToInt32(conn.LastInsertRowId);
            conn.Close();

            return rowId;
        }

        public int CreateRecipe(int cookBookId, string recipeName, List<IingredientLine> ingredientsData, string instructions)
        {
            int recipeId;

            conn.Open();
            // Insert recipe
            using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
                cmd.CommandText = @"INSERT INTO RECIPE (Name, Directions, CookbookID) VALUES(@name, @directions, @bookID)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@name", recipeName));
                cmd.Parameters.Add(new SQLiteParameter("@Directions", instructions));
                cmd.Parameters.Add(new SQLiteParameter("@bookID", cookBookId));
                cmd.ExecuteNonQuery();
            }
            // Get ID
            recipeId = Convert.ToInt32(conn.LastInsertRowId);

            // Innsert ingredientlines
            foreach(IingredientLine ingredientData in ingredientsData) {
                using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
                    cmd.CommandText = @"INSERT INTO INGREDIENTLINE (RecipeID, IngredientID, Quantity, Unit, ID) VALUES(@recipeID, @ingredientID, @quantity, @unit, null)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SQLiteParameter("@recipeID", recipeId));
                    cmd.Parameters.Add(new SQLiteParameter("@ingredientId", ingredientData.Ingredient.ID));
                    cmd.Parameters.Add(new SQLiteParameter("@quantity", ingredientData.Quantity));
                    cmd.Parameters.Add(new SQLiteParameter("@unit", ingredientData.Unit));
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();

            return recipeId;
        }

        public List<Dictionary<string, object>> GetAllIngredients()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            
            conn.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT Name, ID FROM INGREDIENT;", conn)) {
                using(SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Dictionary<string, object> context = new Dictionary<string, object>();
                        context["name"] = reader["Name"];
                        context["id"] = Convert.ToInt32(reader["ID"]);
                        data.Add(context);
                    }
                }

            }
            
            conn.Close();

            return data;
        }

        public List<Dictionary<string, object>> GetCookBooks()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            conn.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT Title, Author, ID FROM COOKBOOK;", conn)) {
                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Dictionary<string, object> context = new Dictionary<string, object>();
                        context["title"] = reader["Title"];
                        context["author"] = reader["Author"];
                        context["id"] = Convert.ToInt32(reader["ID"]);
                        data.Add(context);
                    }
                }

            }
            conn.Close();

            return data;
        }

        public List<Dictionary<string, object>> GetIngredients(int recipeID)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            conn.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
                cmd.CommandText = @"SELECT I.Name, IL.Quantity, IL.Unit FROM INGREDIENT AS I INNER JOIN INGREDIENTLINE AS IL ON IL.IngredientID = I.ID WHERE IL.RecipeID = @ID;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SQLiteParameter("@ID", recipeID));

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Dictionary<string, object> context = new Dictionary<string, object>();
                        context["name"] = reader["Name"];
                        context["quantity"] = reader["Quantity"];
                        context["unit"] = reader["Unit"];
                        data.Add(context);
                    }
                }

            }
            conn.Close();

            return data;
        }

        public List<Dictionary<string, object>> GetRecipies(int CookBookID)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            // get main data
            conn.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT Name, Directions, ID FROM RECIPE WHERE CookbookID=@bookId;", conn)) {
                cmd.Parameters.Add(new SQLiteParameter("@bookId", CookBookID));
                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Dictionary<string, object> context = new Dictionary<string, object>();
                        context["name"] = reader["Name"];
                        context["directions"] = reader["Directions"];
                        context["id"] = Convert.ToInt32(reader["ID"]);
                        data.Add(context);
                    }
                }

            }
            conn.Close();

            foreach(Dictionary<string, object> context in data) {
                context["ingredients"] = GetIngredients((int)context["id"]);
            }

            return data;
        }
    }
}
