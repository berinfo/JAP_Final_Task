using NUnit.Framework;
using server.Models;
using server.Units;
using Server.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormativeAppTest
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void CalculateIngredientCostPrice_TwoDecimal()
        {
            var recipeIng = new RecipeIngredients
            {
                Quantity = 100,
                Unit = UnitEnum.g,
                Ingredient = new Ingredient
                {
                    Name = "Ingredient number one",
                    PurchaseQuantity = 1,
                    PurchasePrice = 2.55m,
                    PurchaseUnit = UnitEnum.kg,
                }
            };
            var res = Calculator.IngredientTotalCost(recipeIng);
            var expectedPrice = 0.255m;
            Assert.AreEqual(expectedPrice, res);
        }
        [Test]
        public void CalculateIngredientCostPrice_WithNoMeasureConversion()
        {
            var recipeIng = new RecipeIngredients
            {
                Quantity = 650,
                Unit = UnitEnum.g,
                Ingredient = new Ingredient
                {
                    Name = "Ingredient number two",
                    PurchaseQuantity = 500,
                    PurchasePrice = 10,
                    PurchaseUnit = UnitEnum.g,
                }
            };
            var res = Calculator.IngredientTotalCost(recipeIng);
            var expectedPrice = 13f;
            Assert.AreEqual(expectedPrice, res);
        }

        [Test]
        public void CalculateIngredientCostPrice_WithConversion()
        {
            var recipeIng = new RecipeIngredients
            {
                Quantity = 1,
                Unit = UnitEnum.l,
                Ingredient = new Ingredient
                {
                    Name = "Ingredient number three",
                    PurchaseQuantity = 50,
                    PurchasePrice = 100,
                    PurchaseUnit = UnitEnum.ml,
                }
            };
            var res = Calculator.IngredientTotalCost(recipeIng);
            var expectedPrice = 2000f;
            Assert.AreEqual(expectedPrice, res);
        }

        [Test]
        public void CalculateRecipeTotalCost_WithTwoIngredients()
        {
            var recipe = new Recipe
            {
                Name = "Recipe one",
                Description = "Description number one",
                CategoryId = 1,
                RecipeIngredients = new List<RecipeIngredients>
                {
                    new RecipeIngredients
                    {
                        Quantity = 100,
                        Unit = UnitEnum.g,
                        Ingredient = new Ingredient
                             {
                                Name = "Ingredient number one",
                                PurchaseQuantity = 1,
                                PurchasePrice = 2,
                                PurchaseUnit = UnitEnum.kg,
                             }
                    },
                    new RecipeIngredients
                    {
                        Quantity = 650,
                        Unit = UnitEnum.g,
                        Ingredient = new Ingredient
                             {
                                Name = "Ingredient number two",
                                PurchaseQuantity = 500,
                                PurchasePrice = 10,
                                PurchaseUnit = UnitEnum.g,
                             }
                    }
                }
            };
            var res = Calculator.RecipeTotalCost(recipe);
            var expectedPrice = 13.2f;

            Assert.AreEqual(expectedPrice, res);
        }
        [Test]
        public void CalculateRecipeTotalCost_WithThreeIngredients_PurchasePriceTwoDecimal()
        {
            var recipe = new Recipe
            {
                Name = "Recipe one",
                Description = "Description number one",
                CategoryId = 1,
                RecipeIngredients = new List<RecipeIngredients>
                {
                    new RecipeIngredients
                    {
                        Quantity = 100,
                        Unit = UnitEnum.g,
                        Ingredient = new Ingredient
                             {
                                Name = "Ingredient number one",
                                PurchaseQuantity = 1,
                                PurchasePrice = 2.70m,
                                PurchaseUnit = UnitEnum.kg,
                             }
                    },
                    new RecipeIngredients
                    {
                        Quantity = 650,
                        Unit = UnitEnum.g,
                        Ingredient = new Ingredient
                             {
                                Name = "Ingredient number two",
                                PurchaseQuantity = 500,
                                PurchasePrice = 10.55m,
                                PurchaseUnit = UnitEnum.g,
                             }
                    },
                    new RecipeIngredients
                    {
                        Quantity = 1,
                        Unit = UnitEnum.l,
                        Ingredient = new Ingredient
                             {
                                Name = "Ingredient number three",
                                PurchaseQuantity = 50,
                                PurchasePrice = 100,
                                PurchaseUnit = UnitEnum.ml,
                             }
                    }
                }
            };
            var res = Calculator.RecipeTotalCost(recipe);
            var expectedPrice = 2013.985m;

            Assert.AreEqual(expectedPrice, res);
        }
        [Test]
        public void CalculateRecipeTotalCost_IngredientsMeasuredInGrams()
        {
            var recipe = new Recipe
            {
                Name = "Recipe one",
                Description = "Description number one",
                CategoryId = 1,
                RecipeIngredients = new List<RecipeIngredients>
                {
                    new RecipeIngredients
                    {
                        Quantity = 500,
                        Unit = UnitEnum.g,
                        Ingredient = new Ingredient
                             {
                                Name = "Ingredient number one",
                                PurchaseQuantity = 25,
                                PurchasePrice = 30,
                                PurchaseUnit = UnitEnum.kg,
                             }
                    },
                    new RecipeIngredients
                    {
                        Quantity = 650,
                        Unit = UnitEnum.g,
                        Ingredient = new Ingredient
                             {
                                Name = "Ingredient number two",
                                PurchaseQuantity = 500,
                                PurchasePrice = 10,
                                PurchaseUnit = UnitEnum.g,
                             }
                    }
                }
            };
            var res = Calculator.RecipeTotalCost(recipe);
            var expectedPrice = 13.6f;

            Assert.AreEqual(expectedPrice, res);
        }
    }

}
