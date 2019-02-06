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
using ReciWizGUI.Widgets;
using RecipeLib.Application;
using RecipeLib.Model;

namespace ReciWizGUI.Pages
{
    /// <summary>
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Page
    {
        private readonly int _bookId;

        public CreateRecipe(int bookID, RoutedEventHandler listener)
        {
            InitializeComponent();
            _bookId = bookID;

            IngredientContainer.Children.Clear();

            ingredientAdd.Click += IngredientAdd;
            IngredientContainer.Children.Add(new IngredientInput());

            createBtn.Click += createRecipe;
            createBtn.Click += listener;
            this.KeyDown += OnKey;
        }

        private void IngredientAdd(object sender, EventArgs e)
        {
            IngredientContainer.Children.Add(new IngredientInput());
        }

        private void createRecipe(object sender, EventArgs e)
        {
            // Pack ingredient data
            List<IingredientLine> ingredients = new List<IingredientLine>();
            foreach(UIElement ingredient in IngredientContainer.Children) {
                ingredients.Add(((IngredientInput)ingredient).GetIngredientLine());
            }

            TextRange instructions = new TextRange(
                    Instructions.Document.ContentStart,
                    Instructions.Document.ContentEnd
                );

            Controller.GetInstance().CreateRecipe(_bookId, RecipeName.Text, ingredients, instructions.Text);
        }

        private void OnKey(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && !RecipeName.IsFocused) {
                IngredientInput input = new IngredientInput();
                IngredientContainer.Children.Add(input);
                input.Select();
            }
        }

    }
}
