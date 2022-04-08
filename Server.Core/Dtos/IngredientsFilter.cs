using server.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Dtos
{
    public abstract class IngredientsFilter
    {
        public string Name { get; set; }
        public decimal? MinQuant { get; set; }
        public decimal? MaxQuant { get; set; }
        public UnitEnum UnitEnum { get; set; }
    }
}
