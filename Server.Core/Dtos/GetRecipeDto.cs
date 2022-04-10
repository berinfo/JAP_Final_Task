using System.Collections.Generic;

namespace server.Dtos
{
    public class GetRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public decimal Price { get; set; }
        public GetCategoryDto Category { get; set; } 
        public List<GetRecipeIngredientsDto> RecipeIngredients { get; set; }
        public decimal RecommSellingPrice { get; set; }
    }
}
