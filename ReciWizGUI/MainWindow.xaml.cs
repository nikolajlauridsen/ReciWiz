using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using RecipeLib.Application;

namespace ReciWizGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();
        public MainWindow()
        {
            InitializeComponent();

            foreach(Dictionary<string, object> book in controller.GetBooks()) {
                Button button = new Button();
                button.Content = (string)book["name"];
                button.Width = 200;
                button.Height = 50;
                button.Background = BookPanel.Background;
                button.BorderThickness = new Thickness(2);
                button.FontSize = 16;

                BookPanel.Children.Add(button);
            }
        }

        public void Test()
        {

        }
    }
}
