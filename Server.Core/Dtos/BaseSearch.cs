using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Dtos
{
    public class BaseSearch
    {
        public int? Skip { get; set; }
        public int? PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public IngredientsFilter IngredientsFilter { get; set; }
    }
}
