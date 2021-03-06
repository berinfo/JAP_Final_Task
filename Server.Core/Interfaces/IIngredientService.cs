using server.Dtos;
using server.Models;
using server.Response;
using Server.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IIngredientService
    {
        Task<ServiceResponse<List<GetIngredientDto>>> GetIngredients(BaseSearch search);
        Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients();
        Task<ServiceResponse<GetIngredientDto>> GetIngredient(int id);
        Task<ServiceResponse<GetIngredientDto>> CreateIngredient(AddIngredientDto newIngredient);
        Task<ServiceResponse<GetIngredientDto>> DeleteIngredient(int id);
        Task<ServiceResponse<GetIngredientDto>> UpdateIngredient(int id, AddIngredientDto newIngredient);
    }
}
