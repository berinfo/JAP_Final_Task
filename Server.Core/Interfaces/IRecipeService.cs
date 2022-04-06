using server.Dtos;
using server.Models;
using server.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IRecipeService
    {
        Task<ServiceResponse<GetRecipeDto>> GetOneRecipe(int recipeId);
        Task<ServiceResponse<GetRecipeDto>> CreateRecipe(CreateRecipeDto newRecipe);
        Task<ServiceResponse<IEnumerable<GetRecipeByCategoryDto>>> GetRecipesByCategory(int categoryId, int skip, int pageSize);
        Task<ServiceResponse<List<GetRecipeDto>>> SearchRecipes(int categoryId, string word );
    }
}
