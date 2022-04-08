using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Datas;
using server.Dtos;
using server.Models;
using server.Response;
using server.Units;
using Server.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public RecipeService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<GetRecipeDto>> GetOneRecipe(int id)
        {
            var serviceResponse = new ServiceResponse<GetRecipeDto>();
            var dbRecipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (dbRecipe != null)
            {
                var dbRecipeDto = _mapper.Map<GetRecipeDto>(dbRecipe);

                serviceResponse.Data = new GetRecipeDto
                {
                    Id = dbRecipeDto.Id,
                    Name = dbRecipeDto.Name,
                    Description = dbRecipeDto.Description,
                    Price = Calculator.RecipeTotalCost(dbRecipe),
                    Category = dbRecipeDto.Category,
                    RecipeIngredients = dbRecipeDto.RecipeIngredients
                };
                return serviceResponse;
            } else
            {
                throw new Exception();
            }  
        }
        public async Task<ServiceResponse<GetRecipeDto>> CreateRecipe(CreateRecipeDto newRecipe)
        {
            if(newRecipe.RecipeIngredients.Count == 0)
            {
                throw new ArgumentException("Recipe must have ingredients");
            }
            if (newRecipe.RecipeIngredients.GroupBy(x => x.IngredientId).Any(x => x.Count() > 1))
            {
                throw new ArgumentException("Can not add same ingredient");
            }
            
            var recipe = _mapper.Map<Recipe>(newRecipe);
            await _context.Recipes.AddAsync(recipe);
         //   await _context.SaveChangesAsync();

            var ingredients = new List<RecipeIngredients>();
            foreach (var ingredient in newRecipe.RecipeIngredients)
            {
                ingredients.Add(new RecipeIngredients()
                {
                    IngredientId = ingredient.IngredientId,
                    RecipeId = recipe.Id,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit,
                });
            }
          //  await _context.RecipeIngredients.AddRangeAsync(ingredients);
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetRecipeDto>()
            {
                Data = _mapper.Map<GetRecipeDto>(recipe)
            };
        }
        public async Task<ServiceResponse<IEnumerable<GetRecipeByCategoryDto>>> GetRecipesByCategory(int categoryId, int skip, int pageSize)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetRecipeByCategoryDto>>();

             var dbRecipes = await _context.Recipes
                .Include(i => i.RecipeIngredients)
                .ThenInclude(ing => ing.Ingredient)
                .Include(r=> r.Category)
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();

            if(dbRecipes.Count != 0)
            {
                var recipesToReturn = dbRecipes.Select(r => new GetRecipeByCategoryDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    TotalCost = Calculator.RecipeTotalCost(r)
                });

                serviceResponse.Data = recipesToReturn
                    .Skip(skip)
                    .Take(pageSize)
                    .OrderBy(r => r.TotalCost).ToList();
                serviceResponse.Success = true;
                return serviceResponse;
            }
            else
            {
                throw new Exception();
            }

        }
        public async Task<ServiceResponse<List<GetRecipeDto>>> SearchRecipes(int categoryId, string word)
        {
            var dbRecipes = await _context.Recipes
                .Include(i => i.RecipeIngredients)
                .ThenInclude(r => r.Ingredient)
                .Where(c => c.CategoryId == categoryId)
               // .Where(r => r.Name == word)
                .Where(r => r.Name.Contains(word) || r.Description.Contains(word) || r.RecipeIngredients.Any(reci => reci.Ingredient.Name.Contains(word)))
                .ToListAsync();

            var recipesToReturn = dbRecipes.Select(c => _mapper.Map<GetRecipeDto>(c)).ToList();

            return new ServiceResponse<List<GetRecipeDto>>()
            {
                Data = recipesToReturn
            };
        }
        public async Task<ServiceResponse<GetRecipeDto>> DeleteRecipe(int id)
        {
            var recipeToDelete = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetRecipeDto>()
            {
                Success = true,
                Message = "Successfully deleted recipe"
            };
        }

        public async Task<ServiceResponse<GetRecipeDto>> UpdateRecipe(int id, CreateRecipeDto newRecipe)
        {
            var recipeToUpdate = await _context.Recipes.Include(ri => ri.RecipeIngredients)
                                                        .FirstOrDefaultAsync(r => r.Id == id);

            if (newRecipe.Name.Length == 0 || newRecipe.Description.Length == 0)
                    throw new ArgumentException("Name or description are empty");
            if (newRecipe.RecipeIngredients.Count == 0)
                throw new ArgumentException("Recipe must have ingredients");
            if (newRecipe.RecipeIngredients.GroupBy(x => x.IngredientId).Any(x => x.Count() > 1))
                throw new ArgumentException("Can not add same ingredient");
            
            var ingredients = newRecipe.RecipeIngredients.Select(ri => new RecipeIngredients
            {
                RecipeId = recipeToUpdate.Id,
                IngredientId = ri.IngredientId,
                Quantity = ri.Quantity,
                Unit = ri.Unit,
            }).ToList();

            recipeToUpdate.Name = newRecipe.Name;
            recipeToUpdate.CategoryId = newRecipe.CategoryId;
            recipeToUpdate.Description = newRecipe.Description;
            recipeToUpdate.RecipeIngredients = ingredients;
            
            await _context.SaveChangesAsync();
           
            var recipeToReturn = _mapper.Map<GetRecipeDto>(recipeToUpdate);
            
            return new ServiceResponse<GetRecipeDto>()
            {
                Data = recipeToReturn,
                Message = "Successfully updated",
                Success = true
            };
        }
    }
}
