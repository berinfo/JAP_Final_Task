using server.Dtos;
using server.Models;
using server.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetCategories(int n);
    }
}
