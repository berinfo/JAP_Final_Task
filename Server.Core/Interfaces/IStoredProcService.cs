using server.Response;
using server.Units;
using Server.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Interfaces
{
    public interface IStoredProcService
    {
        Task<IEnumerable<RecipesWith6IngredientsDto>> GetRecipesWith6orMoreIngredients();
        Task<IEnumerable<RecipesByCategorySpDto>> GetRecipesByCategorySp();
        Task<IEnumerable<IngredientUsedCountSp>> GetMostUsedIngredients( int minquant, int maxquant, UnitEnum unit );
    }
}
