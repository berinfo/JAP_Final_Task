using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Models;
using server.Response;
using server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
      
        public async Task<IActionResult> Get(int n)
        {
            return Ok(await _categoryService.GetCategories(n));
        }
    }
}

