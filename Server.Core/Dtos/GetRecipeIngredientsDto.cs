using server.Models;
using server.Units;

namespace server.Dtos
{
    public class GetRecipeIngredientsDto
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        
        public decimal Quantity { get; set; }
        public UnitEnum Unit { get; set; }
        public GetIngredientDto Ingredient { get; set; }
    }
}
