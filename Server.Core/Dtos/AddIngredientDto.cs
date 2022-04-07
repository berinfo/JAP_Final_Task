using server.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Dtos
{
    public class AddIngredientDto
    {
        public string Name { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public UnitEnum PurchaseUnit { get; set; }
    }
}
