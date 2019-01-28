﻿using System;
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

namespace ReciWizGUI.Pages
{
    /// <summary>
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Page
    {
        private int BookID;

        public CreateRecipe(int bookID, RoutedEventHandler listener)
        {
            InitializeComponent();
            BookID = bookID;

            IngredientContainer.Children.Clear();

            ingredientAdd.Click += IngredientAdd;
            IngredientContainer.Children.Add(new IngredientInput());

            createBtn.Click += createRecipe;
            createBtn.Click += listener;

        }

        public void IngredientAdd(object sender, EventArgs e)
        {
            IngredientContainer.Children.Add(new IngredientInput());
        }

        private void createRecipe(object sender, EventArgs e)
        {
            // Pack ingredient data
            List<Dictionary<string, object>> ingredientData = new List<Dictionary<string, object>>();
            foreach(UIElement ingredient in IngredientContainer.Children) {
                ingredientData.Add(((IngredientInput)ingredient).GetIngredientData());
            }

            TextRange instructions = new TextRange(
                    Instructions.Document.ContentStart,
                    Instructions.Document.ContentEnd
                );

            Controller.GetInstance().CreateRecipe(BookID, RecipeName.Text, ingredientData, instructions.Text);
        }

    }
}