using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Dtos
{
    public class RecipesByCategorySpDto
    {
        public string Category_Name { get; set; }
        public string Recipe_Name {  get; set; }
        public int TotalPrice { get; set; }
    }
}
