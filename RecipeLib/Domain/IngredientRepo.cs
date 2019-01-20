using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Domain
{
    class IngredientRepo
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        public Ingredient GetIngredient(string name)
        {
            Ingredient i = FindIngredient(name);
            if(i == null) {
                i = CreateIngredient(name);
            }

            return i;
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
            return new Ingredient(name); 
        }
    }
}
