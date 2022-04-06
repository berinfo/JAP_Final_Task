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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ingredientService.GetIngredients());
        }
    }
}
