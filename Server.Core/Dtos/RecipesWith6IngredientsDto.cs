using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Dtos
{
    public class RecipesWith6IngredientsDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int TotalPrice { get; set; }
        public int TotalIngredientsNumber { get; set; }

    }
}
