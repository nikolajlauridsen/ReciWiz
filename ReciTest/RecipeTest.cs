using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReciLib;

namespace ReciTest
{
    [TestClass]
    public class RecipeTest
    {
        CookbookRepo repo;
        Cookbook b1;
        string BookName = "Testbook";
        string ReciName = "Pandekager";
        string instructions = "Bland ting og steg dem";

        [TestInitialize]
        public void Init()
        {
            repo = new CookbookRepo();
            repo.CreateCookBook(BookName);
            b1 = repo.GetBook(BookName);
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient("Mel", "gr", 400));
            ingredients.Add(new Ingredient("Æg", "stk", 4));
            ingredients.Add(new Ingredient("Mælk", "dl", 4));
            b1.CreateRecipe(ReciName, ingredients, instructions);
        }

        [TestMethod]
        public void CookBookExists()
        {
            
            Assert.IsNotNull(repo.GetBook(BookName));
        }

        [TestMethod]
        public void TestRecipeCreate()
        {
            List<Ingredient> ingredients2 = new List<Ingredient>();
            ingredients2.Add(new Ingredient("Mel", "gr", 400));
            ingredients2.Add(new Ingredient("Æg", "stk", 4));
            ingredients2.Add(new Ingredient("Mælk", "dl", 4));
            string name2 = "Pandekager2";
            string instructions2 = "Bland ting og steg dem";
            b1.CreateRecipe(name2, ingredients2, instructions2);
            Recipe r1 = b1.GetRecipe(name2);

            Assert.IsNotNull(r1);
        }

        [TestMethod]
        public void TestInstructionsSet()
        {
            Recipe r1 = b1.GetRecipe(ReciName);
            Assert.AreEqual(r1.Instructions, instructions);
        }

        [TestMethod]
        public void TestIngredientsAmount()
        {
            Recipe r1 = b1.GetRecipe(ReciName);
            Assert.AreEqual(r1.Ingredients.Count, 3);
        }

    }
}
