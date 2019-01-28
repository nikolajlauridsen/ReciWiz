using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Model
{
    public interface IingredientLine
    {
        Iingredient Ingredient { get; }
        double Quantity { get; }
        string Unit { get; }
    }
}
