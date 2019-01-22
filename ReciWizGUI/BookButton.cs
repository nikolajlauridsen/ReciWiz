using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReciWizGUI
{
    public partial class BookButton : Button
    {
        public int Id;
        private Action clickAction;

        public BookButton(int id, string name, RoutedEventHandler handler) : base()
        {
            this.Id = id;

            this.Click += handler;
            this.Content = name;
            this.Width = 200;
            this.Height = 50;
            this.BorderThickness = new Thickness(2);
            this.FontSize = 16;
        }
    }
}
