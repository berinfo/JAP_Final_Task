using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Models;
using server.Response;
using server.Services;
using Server.Core.Dtos;
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

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto newCategory)
        {
            return Ok(await _categoryService.CreateCategory(newCategory));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
        }
    }
}

