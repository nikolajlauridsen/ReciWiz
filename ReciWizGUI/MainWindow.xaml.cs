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
        readonly Controller _controller;
        private int _chosenBook;

        public MainWindow()
        {
            InitializeComponent();
            _controller = Controller.GetInstance();
            RecipePanel.Children.Clear();
            BookPanel.Children.Clear();
            LoadBooks(null, null);
            ShowCreateBook(null, null);
        }

        private void LoadBooks(object sender, EventArgs e)
        {
            BookPanel.Children.Clear();

            foreach (ICookbook book in _controller.GetBooks()) {
                Button button = new BookButton(book.ID, book.Title, LoadRecipes, DeleteBook);
                button.Background = BookPanel.Background;
                BookPanel.Children.Add(button);
            }

            BookButton addButton = new BookButton(0, "New book", ShowCreateBook, LoadBooks);
            BookPanel.Children.Add(addButton);
        }

        private void ShowCreateBook(object sender, EventArgs e)
        {
            CreateBookWindow window = new CreateBookWindow(LoadBooks);
            RecipePanel.Children.Clear();
            Navigate(window);
        }

        private void LoadRecipes(object sender, EventArgs e)
        {
            RecipePanel.Children.Clear();
            BookButton senderButton = (BookButton)sender;
            _chosenBook = senderButton.ID;
            // Implement getRecipes and change books to that
            foreach(IRecipe recipe in _controller.GetRecipies(senderButton.ID)) {
                Button button = new RecipeButton(recipe.ID, recipe.Title, LoadRecipe, DeleteRecipe);
                RecipePanel.Children.Add(button);
            }

            RecipeButton newButton = new RecipeButton(0, "New recipe", LoadRecipeCreator, DeleteRecipe);
            RecipePanel.Children.Add(newButton);

            LoadRecipeCreator(null, null);
        }

        private void LoadCurrentRecipes(object sender, EventArgs e)
        {
            RecipePanel.Children.Clear();
            foreach (IRecipe recipe in _controller.GetRecipies(_chosenBook)) {
                Button button = new RecipeButton(recipe.ID, recipe.Title, LoadRecipe, DeleteRecipe);
                RecipePanel.Children.Add(button);
            }

            RecipeButton newButton = new RecipeButton(0, "New recipe", LoadRecipeCreator, DeleteRecipe);
            RecipePanel.Children.Add(newButton);
        }

        private void LoadRecipeCreator(object sender, EventArgs e)
        {
            CreateRecipe recipeCreator = new CreateRecipe(_chosenBook, LoadCurrentRecipes);
            Navigate(recipeCreator);
        }

        private void LoadRecipe(object sender, EventArgs e)
        {
            RecipeButton senderButton = (RecipeButton)sender;
            RecipeViewer viewer = new RecipeViewer(_controller.GetRecipe(_chosenBook, senderButton.ID));
            Navigate(viewer);
        }

        private void DeleteRecipe(object sender, EventArgs e)
        {
            RecipeButton btn = (RecipeButton)sender;
            string msg = $"Are you sure you want to delete {btn.Content}?";
            MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                _controller.DeleteRecipe(_chosenBook, btn.ID);
                LoadRecipeCreator(null, null);
                LoadCurrentRecipes(null, null);
            }
            
        }

        private void DeleteBook(object sender, EventArgs e)
        {
            BookButton senderBtn = (BookButton) sender;
            string msg = $"Are you sure you want to delete {senderBtn.Content} and all its recipes";
            MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                Controller.GetInstance().DeleteBook(senderBtn.ID);
                this.LoadBooks(sender, e);
                this.ShowCreateBook(sender, e);
            }
        }

        private void Navigate(Page target) {
            while (ViewHolder.NavigationService.RemoveBackEntry() != null);
            ViewHolder.Navigate(target);
        }
    }
}
