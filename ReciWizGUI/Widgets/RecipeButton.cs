using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ReciWizGUI
{
    public partial class RecipeButton : IDButton
    {
        private readonly RoutedEventHandler _deleteHandler;
        public RecipeButton(int id, string name, RoutedEventHandler onClickHandler, RoutedEventHandler deleteHandler) : base(id, name, onClickHandler)
        {
            this._deleteHandler = deleteHandler;
            this.Width = 200;
            this.Height = 25;
            this.BorderThickness = new Thickness(0, 0, 1, 1);
            this.Background = Brushes.Transparent;

            ContextMenu menu = new ContextMenu();
            MenuItem deleteOption = new MenuItem {
                Header = "Delete"
            };
            deleteOption.Click += DeleteSelf;
            menu.Items.Add(deleteOption);
            this.ContextMenu = menu;
        }

        private void DeleteSelf(object sender, RoutedEventArgs e)
        {
            _deleteHandler(this, e);
        }
    }
}
