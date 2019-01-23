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

namespace ReciWizGUI
{
    /// <summary>
    /// Interaction logic for RecipeViewer.xaml
    /// </summary>
    public partial class RecipeViewer : Page
    {
        public RecipeViewer(Dictionary<string, object> recipeData)
        {
            InitializeComponent();
            LoadRecipe(recipeData);
        }

        private void LoadRecipe(Dictionary<string, object> recipeData)
        {
            IngredientList.Items.Clear();
            // Set name and instructions
            RecipeName.Content = (string)recipeData["name"];
            Instructions.Text = (string)recipeData["instructions"];
            // Add ingredients
            foreach (Dictionary<string, object> ingredientLine in (List<Dictionary<string, object>>)recipeData["ingredients"]) {
                ListViewItem ingredient = new ListViewItem();
                ingredient.Content = $"{ingredientLine["quantity"]} {ingredientLine["unit"]} {ingredientLine["name"]}";
                IngredientList.Items.Add(ingredient);
            }
        }
    }
}
