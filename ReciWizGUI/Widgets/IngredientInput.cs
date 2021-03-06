﻿using System;
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
        private string[] Clearable = { "Quantity", "Unit", "Name" };

        public IngredientInput(string name, string quantity, string unit)
        {
            this.Margin = new Thickness(0, 0, 0, 10);

            ingredient["quantity"] = new TextBox { Text = quantity };
            ingredient["unit"] = new TextBox { Text = unit };
            ingredient["name"] = new TextBox { Text = name };
            

            foreach (TextBox box in ingredient.Values) {
                box.Width = 70;
                box.Margin = new Thickness(0, 0, 10, 0);
                this.Children.Add(box);
                box.GotFocus += ClearText;
            }
        }

        public IngredientInput() : this("Name", "Quantity", "Unit")
        {

        }

        public IingredientLine GetIngredientLine()
        {
            double quantity = Double.Parse(ingredient["quantity"].Text);

            return Controller.GetInstance().CreateIngredientLine(ingredient["name"].Text, quantity, ingredient["unit"].Text);
        }

        public void ClearText(object sender, RoutedEventArgs e)
        {
            TextBox self = (TextBox)sender;
            if (Clearable.Contains(self.Text)){
                self.Clear();
            }   
        }

        public void Select()
        {
            ingredient["quantity"].Focus();
        }

    }
}
