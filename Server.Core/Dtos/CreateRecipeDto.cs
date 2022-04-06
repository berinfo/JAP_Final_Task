using server.Models;
using System.Collections.Generic;

namespace server.Dtos
{
    public class CreateRecipeDto
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<AddRecipeIngredientsDto> RecipeIngredients { get; set; }
        
    }
}

/// vraititi na categoryId