using server.Models;
using server.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.SeedData
{
    public class IngredientData
    {

        public static List<Ingredient> GetIngredientData()
        {
            var ingredients = new List<Ingredient>()
        {
            new Ingredient { Id = 1, Name = "Oil", PurchasePrice = 3, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 2, Name = "Flour", PurchasePrice = 30, PurchaseQuantity = 25, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 3, Name = "Sugar", PurchasePrice = 3, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 4, Name = "Salt", PurchasePrice = 2, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 5, Name = "Olive Oil", PurchasePrice = 20, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 6, Name = "Egg", PurchasePrice = 9, PurchaseQuantity = 30, PurchaseUnit = UnitEnum.pcs },
                 new Ingredient { Id = 7, Name = "Ingredient1", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 8, Name = "Ingredient2", PurchasePrice = 11, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 9, Name = "Ingredient3", PurchasePrice = 12, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 10, Name = "Ingredient4", PurchasePrice = 13, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 11, Name = "Ingredient5", PurchasePrice = 14, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 12, Name = "Ingredient6", PurchasePrice = 15, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 13, Name = "Ingredient7", PurchasePrice = 16, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 14, Name = "Ingredient8", PurchasePrice = 17, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 15, Name = "Ingredient9", PurchasePrice = 18, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 16, Name = "Ingredient10", PurchasePrice = 19, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 17, Name = "Ingredient11", PurchasePrice = 20, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 18, Name = "Ingredient12", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 19, Name = "Ingredient13", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 20, Name = "Ingredient14", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 21, Name = "Ingredient15", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 22, Name = "Ingredient16", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 23, Name = "Ingredient17", PurchasePrice = 10, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 24, Name = "Ingredient18", PurchasePrice = 10, PurchaseQuantity = 3, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 25, Name = "Ingredient19", PurchasePrice = 10, PurchaseQuantity = 4, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 26, Name = "Ingredient20", PurchasePrice = 10, PurchaseQuantity = 5, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 27, Name = "Ingredient21", PurchasePrice = 10, PurchaseQuantity = 6, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 28, Name = "Ingredient22", PurchasePrice = 10, PurchaseQuantity = 7, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 29, Name = "Ingredient23", PurchasePrice = 10, PurchaseQuantity = 8, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 30, Name = "Ingredient24", PurchasePrice = 10, PurchaseQuantity = 9, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 31, Name = "Ingredient25", PurchasePrice = 22, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 32, Name = "Ingredient26", PurchasePrice = 23, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 33, Name = "Ingredient27", PurchasePrice = 24, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 34, Name = "Ingredient28", PurchasePrice = 25, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 35, Name = "Ingredient29", PurchasePrice = 26, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 36, Name = "Ingredient30", PurchasePrice = 27, PurchaseQuantity = 3, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 37, Name = "Ingredient31", PurchasePrice = 28, PurchaseQuantity = 4, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 38, Name = "Ingredient32", PurchasePrice = 10, PurchaseQuantity = 5, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 39, Name = "Ingredient33", PurchasePrice = 10, PurchaseQuantity = 6, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 40, Name = "Ingredient34", PurchasePrice = 12, PurchaseQuantity = 7, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 41, Name = "Ingredient35", PurchasePrice = 13, PurchaseQuantity = 3, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 42, Name = "Ingredient36", PurchasePrice = 14, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.kg },
                 new Ingredient { Id = 43, Name = "Ingredient37", PurchasePrice = 15, PurchaseQuantity = 3, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 44, Name = "Ingredient38", PurchasePrice = 16, PurchaseQuantity = 2, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 45, Name = "Ingredient39", PurchasePrice = 17, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 46, Name = "Ingredient40", PurchasePrice = 18, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 47, Name = "Ingredient41", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 48, Name = "Ingredient42", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 49, Name = "Ingredient43", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l },
                 new Ingredient { Id = 50, Name = "Ingredient44", PurchasePrice = 10, PurchaseQuantity = 1, PurchaseUnit = UnitEnum.l }
        };
            return ingredients;
        }
    }
}



    
