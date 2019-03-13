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
        private RoutedEventHandler _deleteClick;

        public BookButton(int id, string name, RoutedEventHandler onClickHandler, RoutedEventHandler deleteHandler) : base(id, name, onClickHandler)
        {
            this.Width = 200;
            this.Height = 50;
            this.BorderThickness = new Thickness(0, 0, 0, 1);
            this.BorderBrush = Brushes.Black;
            this.Background = Brushes.Transparent;
            this.FontSize = 16;
            _deleteClick = deleteHandler;

            ContextMenu menu = new ContextMenu();
            MenuItem deleteOption = new MenuItem {Header = "Delete"};
            deleteOption.Click += (sender, e) => _deleteClick(this, e);
            menu.Items.Add(deleteOption);
            this.ContextMenu = menu;
        }
    }
}
