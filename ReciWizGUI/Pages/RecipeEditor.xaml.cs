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
using RecipeLib.Model;
using ReciWizGUI.Widgets;

namespace ReciWizGUI.Pages
{
    /// <summary>
    /// Interaction logic for RecipeEditor.xaml
    /// </summary>
    public partial class RecipeEditor : Page
    {
        private int _bookId;
        private IRecipe _recipe;

        public RecipeEditor(int bookId, IRecipe recipe)
        {
            InitializeComponent();
            _bookId = bookId;
            _recipe = recipe;

            IngredientContainer.Children.Clear();
            LoadContent();
            this.KeyDown += (sender, keyEvent) =>
            {
                if (keyEvent.Key == Key.Enter && !RecipeName.IsFocused)
                {
                    IngredientInput input = new IngredientInput();
                    IngredientContainer.Children.Add(input);
                    input.Select();
                }
            };
        }

        private void LoadContent()
        {
            RecipeName.Text = _recipe.Title;
            Instructions.AppendText(_recipe.Instructions);
            foreach (IingredientLine ingredientLine in _recipe.Ingredients)
            {
                IngredientContainer.Children.Add(new IngredientInput(ingredientLine.Ingredient.Name,
                    ingredientLine.Quantity.ToString(), ingredientLine.Unit));
            }
        }
    }
}
