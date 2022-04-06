using server.Models;
using server.Units;

namespace server.Dtos
{
    public class AddRecipeIngredientsDto
    {
       // public string Name { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
        public UnitEnum Unit { get; set; }
    }
}
