using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace ReciWizGUI
{
    public partial class BookButton : IDButton
    {
        public BookButton(int id, string name, RoutedEventHandler handler) : base(id, name, handler)
        {
            this.Width = 200;
            this.Height = 50;
            this.BorderThickness = new Thickness(0, 0, 0, 1);
            this.BorderBrush = Brushes.Black;
            this.Background = Brushes.Transparent;
            this.FontSize = 16;
        }
    }
}
