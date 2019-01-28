using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Model
{
    public interface IRecipe : IPersistable
    {
        string Title { get; }
        string Instructions { get; }

        List<IingredientLine> Ingredients { get; }
    }
}
