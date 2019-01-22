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
    /// 
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();
        public MainWindow()
        {
            InitializeComponent();
            LoadBooks();

        }


        public void LoadBooks()
        {
            foreach (Dictionary<string, object> book in controller.GetBooks()) {
                Button button = new BookButton((int)book["id"], (string)book["name"], LoadRecipies);
                button.Background = BookPanel.Background;
                BookPanel.Children.Add(button);
            }
        }

        public void LoadRecipies(object sender, EventArgs e)
        {
            RecipePanel.Children.Clear();
            BookButton senderButton = (BookButton)sender;
            // Implement getRecipies and change books to that
            foreach(Dictionary<string, object> recipe in controller.GetRecipies(senderButton.Id)) {
                Button button = new Button();
                button.Height = 25;
                button.Width = 200;
                button.Content = (string)recipe["name"];
                RecipePanel.Children.Add(button);
            }
        }
    }
}
