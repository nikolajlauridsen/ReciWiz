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
using RecipeLib.Model;

using ReciWizGUI.Pages;

namespace ReciWizGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Controller controller;
        private int chosenbook;

        public MainWindow()
        {
            InitializeComponent();
            controller = Controller.GetInstance();
            RecipePanel.Children.Clear();
            BookPanel.Children.Clear();
            LoadBooks(null, null);
            ShowCreateBook(null, null);
        }

        public void LoadBooks(object sender, EventArgs e)
        {
            BookPanel.Children.Clear();

            foreach (ICookbook book in controller.GetBooks()) {
                Button button = new BookButton(book.ID, book.Title, LoadRecipies, LoadBooks);
                button.Background = BookPanel.Background;
                BookPanel.Children.Add(button);
            }

            BookButton addButton = new BookButton(0, "New book", ShowCreateBook, LoadBooks);
            BookPanel.Children.Add(addButton);
        }

        public void ShowCreateBook(object sender, EventArgs e)
        {
            CreateBookWindow window = new CreateBookWindow(LoadBooks);
            RecipePanel.Children.Clear();
            Navigate(window);
        }

        public void LoadRecipies(object sender, EventArgs e)
        {
            RecipePanel.Children.Clear();
            BookButton senderButton = (BookButton)sender;
            chosenbook = senderButton.ID;
            // Implement getRecipies and change books to that
            foreach(IRecipe recipe in controller.GetRecipies(senderButton.ID)) {
                Button button = new RecipeButton(recipe.ID, recipe.Title, LoadRecipe, DeleteRecipe);
                RecipePanel.Children.Add(button);
            }

            RecipeButton newButton = new RecipeButton(0, "New recipe", LoadRecipeCreator, DeleteRecipe);
            RecipePanel.Children.Add(newButton);

            LoadRecipeCreator(null, null);
        }

        public void LoadCurrentRecipies(object sender, EventArgs e)
        {
            RecipePanel.Children.Clear();
            // Implement getRecipies and change books to that
            foreach (IRecipe recipe in controller.GetRecipies(chosenbook)) {
                Button button = new RecipeButton(recipe.ID, recipe.Title, LoadRecipe, DeleteRecipe);
                RecipePanel.Children.Add(button);
            }

            RecipeButton newButton = new RecipeButton(0, "New recipe", LoadRecipeCreator, DeleteRecipe);
            RecipePanel.Children.Add(newButton);
        }

        public void LoadRecipeCreator(object sender, EventArgs e)
        {
            CreateRecipe recipeCreator = new CreateRecipe(chosenbook, LoadCurrentRecipies);
            Navigate(recipeCreator);
        }

        public void LoadRecipe(object sender, EventArgs e)
        {
            RecipeButton senderButton = (RecipeButton)sender;
            RecipeViewer viewer = new RecipeViewer(controller.GetRecipe(chosenbook, senderButton.ID));
            Navigate(viewer);
        }
        
        public void DeleteRecipe(object sender, EventArgs e)
        {
            RecipeButton btn = (RecipeButton)sender;
            controller.DeleteRecipe(chosenbook, btn.ID);
            ShowCreateBook(null, null);
        }

        private void Navigate(Page target) {
            while (ViewHolder.NavigationService.RemoveBackEntry() != null) ;
            ViewHolder.Navigate(target);
        }
    }
}
