using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReciWizGUI
{
    public abstract class IDButton : Button
    {
        public int ID;

        public IDButton(int id, string name, RoutedEventHandler handler)
        {
            this.ID = id;

            this.Click += handler;
            this.Content = name;
        }
        public IDButton(int id, string name)
        {
            this.ID = id;
            this.Content = name;
        }
    }
}
