using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Model
{
    public interface ICookBook : IPersistable
    {
        string Title { get; }
        string Author { get; }

    }
}
