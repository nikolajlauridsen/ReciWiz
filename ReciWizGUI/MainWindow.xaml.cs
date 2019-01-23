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
        private int chosenbook;

        public MainWindow()
        {
            InitializeComponent();
            RecipePanel.Children.Clear();
            BookPanel.Children.Clear();
            LoadBooks(null, null);
            ShowCreateBook(null, null);
        }

        public void LoadBooks(object sender, EventArgs e)
        {
            BookPanel.Children.Clear();

            foreach (Dictionary<string, object> book in controller.GetBooks()) {
                Button button = new BookButton((int)book["id"], (string)book["name"], LoadRecipies);
                button.Background = BookPanel.Background;
                BookPanel.Children.Add(button);
            }

            BookButton addButton = new BookButton(0, "New book", ShowCreateBook);
            BookPanel.Children.Add(addButton);
        }

        public void ShowCreateBook(object sender, EventArgs e)
        {
            CreateBookWindow window = new CreateBookWindow(LoadBooks, controller);
            RecipePanel.Children.Clear();
            ViewHolder.Navigate(window);
        }

        public void LoadRecipies(object sender, EventArgs e)
        {
            RecipePanel.Children.Clear();
            BookButton senderButton = (BookButton)sender;
            chosenbook = senderButton.ID;
            // Implement getRecipies and change books to that
            foreach(Dictionary<string, object> recipe in controller.GetRecipies(senderButton.ID)) {
                Button button = new RecipeButton((int)recipe["id"], (string)recipe["name"], LoadRecipe);
                RecipePanel.Children.Add(button);
            }
        }

        public void LoadRecipe(object sender, EventArgs e)
        {
            RecipeButton senderButton = (RecipeButton)sender;
            RecipeViewer viewer = new RecipeViewer(controller.GetRecipe(chosenbook, senderButton.ID));
            ViewHolder.Navigate(viewer);
        }
    }
}
