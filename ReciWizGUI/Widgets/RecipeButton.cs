using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        private readonly RoutedEventHandler _editHandler;
        public RecipeButton(int id, string name, RoutedEventHandler onClickHandler, RoutedEventHandler deleteHandler, RoutedEventHandler editHandler) : base(id, name, onClickHandler)
        {
            this._deleteHandler = deleteHandler;
            _editHandler = editHandler;
            this.Width = 200;
            this.Height = 25;
            this.BorderThickness = new Thickness(0, 0, 1, 1);
            this.Background = Brushes.Transparent;

            ContextMenu menu = new ContextMenu();

            MenuItem editOption = new MenuItem() {
                Header = "Edit"
            };
            editOption.Click += (sender, e) => _editHandler(this, e);
            menu.Items.Add(editOption);

            MenuItem deleteOption = new MenuItem {
                Header = "Delete"
            };
            deleteOption.Click += (sender, e) => _deleteHandler(this, e);
            menu.Items.Add(deleteOption);

            this.ContextMenu = menu;
        }
    }
}
