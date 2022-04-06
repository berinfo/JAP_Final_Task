using MoreLinq;
using server.Models;
using server.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.SeedData
{
    public class RecipeIngredientsData
    {
    public static List <RecipeIngredients> GetRecipeIngredientsData()
        {
            var recipeIngredients = new List <RecipeIngredients> ();
            for (int i = 1; i < 50; i++)
            {
                Random random = new Random();
                var randomIngredient = random.Next(1, 50);
                var randomRecipe = random.Next(1,50);
                var randomQuantity = random.Next(1, 5);
                recipeIngredients.Add(new RecipeIngredients
                {
                    RecipeId = randomRecipe,
                    IngredientId = randomIngredient,
                    Quantity = randomQuantity,
                    Unit = UnitEnum.kg
                });

            }
            for (int i = 1; i < 50; i++)
            {
                Random random = new Random();
                var randomIngredient = random.Next(1, 50);
                var randomRecipe = random.Next(1, 50);
                var randomQuantity = random.Next(50,500);
                recipeIngredients.Add(new RecipeIngredients
                {
                    RecipeId = randomRecipe,
                    IngredientId = randomIngredient,
                    Quantity = randomQuantity,
                    Unit = UnitEnum.g
                });
            }
            for (int i = 1; i < 50; i++)
            {
                Random random = new Random();
                var randomIngredient = random.Next(1, 50);
                var randomRecipe = random.Next(1, 50);
                var randomQuantity = random.Next(1,5);
                recipeIngredients.Add(new RecipeIngredients
                {
                    RecipeId = randomRecipe,
                    IngredientId = randomIngredient,
                    Quantity = randomQuantity,
                    Unit = UnitEnum.l
                });
            }
            for (int i = 1; i < 50; i++)
            {
                Random random = new Random();
                var randomIngredient = random.Next(1, 50);
                var randomRecipe = random.Next(1, 50);
                var randomQuantity = random.Next(50, 500);
                recipeIngredients.Add(new RecipeIngredients
                {
                    RecipeId = randomRecipe,
                    IngredientId = randomIngredient,
                    Quantity = randomQuantity,
                    Unit = UnitEnum.ml
                });
            }
            recipeIngredients = recipeIngredients.DistinctBy(x => new { x.RecipeId, x.IngredientId }).ToList();
            return recipeIngredients;
        }
    }
}
