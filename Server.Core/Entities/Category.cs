using Server.Common;
using System;
using System.Collections.Generic;

namespace server.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }    
        public List<Recipe> Recipes { get; set; }
    }
}
