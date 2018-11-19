using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciLib
{
    public class Ingredient
    {
        public string Name;
        public double Quantity;
        public string Unit;

        public Ingredient(string name, string unit, double qty)
        {
            Name = name;
            Unit = unit;
            Quantity = qty;
        }
    }
}
