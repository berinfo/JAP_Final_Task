using server.Units;
using Server.Common;
using System.Collections.Generic;

namespace server.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }   
        public decimal PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public UnitEnum PurchaseUnit { get; set; }   
        public List<RecipeIngredients> RecipeIngredients { get; set; }
        
    }
}
