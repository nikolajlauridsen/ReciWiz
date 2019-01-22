using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReciWizGUI
{
    public partial class RecipeButton : IDButton
    {
        public RecipeButton(int id, string name, RoutedEventHandler handler) : base(id, name, handler)
        {
            this.Width = 200;
            this.Height = 25;
        }
    }
}
