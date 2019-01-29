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
        private RoutedEventHandler DeleteHandler;
        public RecipeButton(int id, string name, RoutedEventHandler handler, RoutedEventHandler deleteHandler) : base(id, name, handler)
        {
            this.DeleteHandler = deleteHandler;
            this.Width = 200;
            this.Height = 25;
            this.BorderThickness = new Thickness(0, 0, 1, 1);
            this.Background = Brushes.Transparent;

            ContextMenu menu = new ContextMenu();
            MenuItem deleteOption = new MenuItem {
                Header = "Delete"
            };
            deleteOption.Click += deleteSelf;
            menu.Items.Add(deleteOption);
            this.ContextMenu = menu;
        }

        private void deleteSelf(object sender, RoutedEventArgs e)
        {
            string msg = $"Are you sure you want to delete {this.Content}?";
            MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                DeleteHandler(this, e);
            }
        }
    }
}
