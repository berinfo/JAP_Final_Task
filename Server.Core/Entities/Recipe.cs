using Server.Common;
using System.Collections.Generic;

namespace server.Models
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
