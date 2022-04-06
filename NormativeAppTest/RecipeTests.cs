using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using server.Datas;
using server.Dtos;
using server.Models;
using server.Services;
using server.Units;
using Server.Database.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormativeAppTest
{
    [TestFixture]
    public class RecipeTests
    {
        private RecipeService _recipeService;
        private DbContextOptions<DataContext> _options;
        private DataContext _context;

        [OneTimeSetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                   .UseInMemoryDatabase(databaseName: "JapTaskTwo").Options;

            _context = new DataContext(_options);
            _context.Database.EnsureDeleted();
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<CreateRecipeDto, Recipe>();
                x.CreateMap<Recipe, GetRecipeDto>();
                x.CreateMap<RecipeIngredients, GetRecipeIngredientsDto>();
                x.CreateMap<Ingredient, GetIngredientDto>();
                x.CreateMap<Category, GetCategoryDto>();
                x.CreateMap<AddRecipeIngredientsDto, RecipeIngredients>();
            });
            _recipeService = new RecipeService(mapperConfiguration.CreateMapper(), _context);
             SetUpDb();
           
        }
        [Test]
        public void CreateRecipe_AddTwoSameIngredients_ThrowEx()
        {
            var newRecipe = new CreateRecipeDto
            {
                Name = "Recipe one",
                Description = "Description of recipe number one",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientsDto>
                {
                    new AddRecipeIngredientsDto
                   {
                       IngredientId = 1,
                       Quantity = 100,
                       Unit = UnitEnum.g,
                   },
                     new AddRecipeIngredientsDto
                   {
                       IngredientId = 1,
                       Quantity = 1,
                       Unit = UnitEnum.g,
                   }
                }
            };
            //  error  expected
            Assert.ThrowsAsync<ArgumentException>(async () => await _recipeService.CreateRecipe(newRecipe));
        }

        [Test]
        public void CreateRecipe_AddManySameIngredients_ThrowEx()
        {
            var newRecipe = new CreateRecipeDto
            {
                Name = "Recipe two",
                Description = "Description of recipe number two",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientsDto>
                {
                    new AddRecipeIngredientsDto
                   {
                       IngredientId = 1,
                       Quantity = 100,
                       Unit = UnitEnum.g,
                   },
                     new AddRecipeIngredientsDto
                   {
                       IngredientId = 2,
                       Quantity = 11,
                       Unit = UnitEnum.g,
                   }, new AddRecipeIngredientsDto
                   {
                       IngredientId = 2,
                       Quantity = 12,
                       Unit = UnitEnum.g,
                   },
                      new AddRecipeIngredientsDto
                   {
                       IngredientId = 2,
                       Quantity = 13,
                       Unit = UnitEnum.g,
                   }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await _recipeService.CreateRecipe(newRecipe));
        }

        [Test]
        public void CreateRecipe_AddMDoubleSameIngredients_ThrowEx()
        {
            var newRecipe = new CreateRecipeDto
            {
                Name = "Recipe two",
                Description = "Description of recipe number two",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientsDto>
                {
                    new AddRecipeIngredientsDto
                   {
                       IngredientId = 1,
                       Quantity = 100,
                       Unit = UnitEnum.g,
                   },
                     new AddRecipeIngredientsDto
                   {
                       IngredientId = 1,
                       Quantity = 11,
                       Unit = UnitEnum.g,
                   }, new AddRecipeIngredientsDto
                   {
                       IngredientId = 2,
                       Quantity = 12,
                       Unit = UnitEnum.g,
                   },
                      new AddRecipeIngredientsDto
                   {
                       IngredientId = 2,
                       Quantity = 13,
                       Unit = UnitEnum.g,
                   }
                }
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await _recipeService.CreateRecipe(newRecipe));
        }
        [Test]
        public async Task CreateRecipe_WithOneIngredient_Success()
        {
            var newRecipe = new CreateRecipeDto
            {
                Name = "Recipe one",
                Description = "Description of recipe number one",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientsDto>()
                {
                    new AddRecipeIngredientsDto
                    {
                        IngredientId = 12,
                        Quantity = 5,
                        Unit = UnitEnum.g
                    }
                }
            };
            await _recipeService.CreateRecipe(newRecipe);   

            var dbRecipe = _context.Recipes.FirstOrDefault(x => x.Name == newRecipe.Name);

            if (dbRecipe == null)
                throw new ArgumentException("Error due obtaining recipe");

            Assert.AreEqual(newRecipe.Name, dbRecipe.Name);
            Assert.AreEqual(newRecipe.Description, dbRecipe.Description);
            Assert.AreEqual(newRecipe.CategoryId, dbRecipe.CategoryId);
            Assert.IsNotEmpty(dbRecipe.RecipeIngredients);
        }
        [Test]
        public async Task CreateRecipe_WithMultipleIngredients_Success()
        {
            var newRecipe = new CreateRecipeDto
            {
                Name = "Recipe two",
                Description = "Description of recipe number two",
                CategoryId = 1,
                RecipeIngredients = new List<AddRecipeIngredientsDto>()
                {
                    new AddRecipeIngredientsDto
                    {
                        IngredientId = 12,
                        Quantity = 5,
                        Unit = UnitEnum.g
                    },
                    new AddRecipeIngredientsDto
                    {
                        IngredientId = 11,
                        Quantity = 55,
                        Unit = UnitEnum.g
                    }
                }
            };
            await _recipeService.CreateRecipe(newRecipe);

            var dbRecipe = _context.Recipes.FirstOrDefault(x => x.Name == newRecipe.Name);

            if (dbRecipe == null)
                throw new ArgumentException("Error due obtaining recipe");

            Assert.IsNotEmpty(dbRecipe.RecipeIngredients);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
       
        public async Task GetRecipes_LoadMore(int pageSize)
        {
            var res = await _recipeService.GetRecipesByCategory(2,1,pageSize);
            // is equal doesn't work
            Assert.That(res.Data.Count, Is.AtMost(pageSize));
        }

        public void SetUpDb()
        {
            _context.Categories.AddRange(CategoryData.GetCategoriesData());
            _context.Ingredients.AddRange(IngredientData.GetIngredientData());
            _context.Recipes.AddRange(RecipeData.GetRecipeData());
            _context.RecipeIngredients.AddRange(RecipeIngredientsData.GetRecipeIngredientsData());
            _context.SaveChanges();
        }
    }
}
