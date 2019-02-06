using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

using RecipeLib.Application;

namespace ReciWizGUI
{
    public partial class BookButton : IDButton
    {
        public BookButton(int id, string name, RoutedEventHandler handler, RoutedEventHandler reloadHandler) : base(id, name, handler)
        {
            this.Width = 200;
            this.Height = 50;
            this.BorderThickness = new Thickness(0, 0, 0, 1);
            this.BorderBrush = Brushes.Black;
            this.Background = Brushes.Transparent;
            this.FontSize = 16;

            ContextMenu menu = new ContextMenu();
            MenuItem deleteOption = new MenuItem();
            deleteOption.Header = "Delete";
            deleteOption.Click += DeleteClick;
            deleteOption.Click += reloadHandler;
            menu.Items.Add(deleteOption);
            this.ContextMenu = menu;
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            string msg = $"Are you sure you want to delete {this.Content}?";
            MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Delete Confirmation", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes) {
                Controller.GetInstance().DeleteBook(this.ID);
            }
        }
    }
}
