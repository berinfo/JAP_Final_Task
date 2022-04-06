using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.SeedData
{
    public class RecipeData
    {
        public static List<Recipe> GetRecipeData()
        {
            var recipes = new List<Recipe>();

            for (int i = 1; i < 50; i++)
            {
                Random random = new Random();
                var randomCategoryId = random.Next(1, 20);
                recipes.Add(new Recipe
                {
                    Id = i,
                    Name = $"Naziv recepta {i}",
                    Description = $"Description of a recipe whos id is ${i}",
                    CategoryId = randomCategoryId,
                    CreatedAt = DateTime.Now
                });
                    
            }
            return recipes;
        }

    }
}
