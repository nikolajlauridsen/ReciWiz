using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using RecipeLib.Application;
using RecipeLib.Model;

namespace ReciWizGUI.Widgets
{
    public partial class IngredientInput : WrapPanel
    {
        public Dictionary<string, TextBox> ingredient = new Dictionary<string, TextBox>();

        public IngredientInput()
        {
            this.Margin = new Thickness(0,0,0,10);
  
            ingredient["quantity"] = new TextBox();
            ingredient["unit"] = new TextBox();
            ingredient["name"] = new TextBox();

            ingredient["quantity"].Text = "Quantity";
            ingredient["unit"].Text = "Unit";
            ingredient["name"].Text = "Name";



            foreach (TextBox box in ingredient.Values) {
                box.Width = 70;
                box.Margin = new Thickness(0, 0, 10, 0);
                this.Children.Add(box);
            }
        }

        public IingredientLine GetIngredientLine()
        {
            double quantity = Double.Parse(ingredient["quantity"].Text);

            return Controller.GetInstance().CreateIngredientLine(ingredient["name"].Text, quantity, ingredient["unit"].Text);
        }

    }
}
