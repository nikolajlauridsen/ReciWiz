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

    }
}
