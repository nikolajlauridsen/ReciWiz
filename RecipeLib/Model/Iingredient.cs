using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Model
{
    public interface Iingredient : IPersistable
    {
        string Name { get; }

    }
}
