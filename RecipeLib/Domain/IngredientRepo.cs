using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeLib.Persistence;

namespace RecipeLib.Domain
{
    class IngredientRepo
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private IDB db = new LiteConnector();

        public IngredientRepo()
        {
            foreach(Dictionary<string, object> ingredientData in db.GetAllIngredients()) {
                Ingredient ingridient = new Ingredient((string)ingredientData["name"], (int)ingredientData["id"]);
                ingredients.Add(ingridient);
            }
        }

        public Ingredient GetIngredient(string name)
        {
            Ingredient i = FindIngredient(name);
            if(i == null) {
                i = CreateIngredient(name);
            }

            return i;
        }

        public IngredientLine CreateIngredientLine(string name, double quantity, string unit)
        {
            Ingredient ingredient = GetIngredient(name);
            return new IngredientLine(ingredient, quantity, unit);
        }
        
        public Ingredient FindIngredient(string name)
        {
            foreach(Ingredient i in ingredients) {
                if (i.Name.Equals(name)) {
                    return i;
                }
            }
            return null;
        }

        private Ingredient CreateIngredient(string name)
        {
            int id = db.CreateIngredient(name);
            return new Ingredient(name, id); 
        }
    }
}
