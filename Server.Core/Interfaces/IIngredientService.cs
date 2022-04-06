using server.Dtos;
using server.Models;
using server.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IIngredientService
    {
        Task<ServiceResponse<List<GetIngredientDto>>> GetIngredients();
    }
}
