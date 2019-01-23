using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReciWizGUI.Widgets
{
    public partial class IngredientInput : WrapPanel
    {
        public Dictionary<string, TextBox> ingredients = new Dictionary<string, TextBox>();

        public IngredientInput()
        {
            this.Margin = new Thickness(0,0,0,10);
  
            ingredients["quantity"] = new TextBox();
            ingredients["unit"] = new TextBox();
            ingredients["name"] = new TextBox();

            ingredients["quantity"].Text = "Quantity";
            ingredients["unit"].Text = "Unit";
            ingredients["name"].Text = "Name";



            foreach (TextBox box in ingredients.Values) {
                box.Width = 70;
                box.Margin = new Thickness(0, 0, 10, 0);
                this.Children.Add(box);
            }
        }

        public Dictionary<string, object> GetIngredientData()
        {
            Dictionary<string, object> context = new Dictionary<string, object>();
            context["name"] = ingredients["name"].Text;
            context["quantity"] = double.Parse(ingredients["quantity"].Text);
            context["unit"] = ingredients["unit"].Text;

            return context;
        }

    }
}
