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

namespace ReciWizGUI
{
    /// <summary>
    /// Interaction logic for RecipeViewer.xaml
    /// </summary>
    public partial class RecipeViewer : Page
    {
        public RecipeViewer(IRecipe recipe)
        {
            InitializeComponent();
            LoadRecipe(recipe);
        }

        private void LoadRecipe(IRecipe recipe)
        {
            IngredientList.Items.Clear();
            // Set name and instructions
            RecipeName.Content = recipe.Title;
            Instructions.Text = recipe.Instructions;
            // Add ingredients
            foreach (IingredientLine line in recipe.Ingredients){
                ListViewItem ingredient = new ListViewItem();
                ingredient.Content = $"{line.Quantity} {line.Unit} {line.Ingredient.Name}";
                IngredientList.Items.Add(ingredient);
            }
        }
    }
}
