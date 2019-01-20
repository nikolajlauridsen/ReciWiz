﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLib.Domain
{
    public class Recipe
    {
        public string Name;
        public string Instructions;

        public List<IngredientLine> Ingredients { get; private set; }
        
        public Recipe(string name, string instructions, List<IngredientLine> ingredients)
        {
            Ingredients = ingredients;
            Name = name;
            Instructions = instructions;
        }

        public Recipe(string name, string instructions): this(name, instructions, null)
        {
            Ingredients = new List<IngredientLine>();
        }

        public void AddIngredient(IngredientLine ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public Dictionary<string, object> GetRecipeData()
        {
            Dictionary<string, object> context = new Dictionary<string, object>();
            context["name"] = Name;
            context["instructions"] = Instructions;
            context["ingredients"] = new List<Dictionary<string, string>>();
            foreach (IngredientLine ingredient in Ingredients) {
                ((List<Dictionary<string, string>>)context["ingredients"]).Add(ingredient.GetContext());
            }
            return context;
        }

    }
}