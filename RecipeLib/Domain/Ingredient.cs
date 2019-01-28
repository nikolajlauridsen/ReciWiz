using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecipeLib.Model;

namespace RecipeLib.Domain
{
    public class Ingredient : Iingredient
    {
        public string Name { get; }
        public int ID { get; }

        public Ingredient(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public Dictionary<string, object> GetContext()
        {
            Dictionary<string, object> context = new Dictionary<string, object>();
            context["name"] = Name;
            context["id"] = ID;
            return context;
        }
    }
}
