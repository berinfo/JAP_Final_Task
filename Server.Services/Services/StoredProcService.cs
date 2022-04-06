using Dapper;
using Microsoft.EntityFrameworkCore;
using server.Datas;
using server.Response;
using server.Units;
using Server.Core.Dtos;
using Server.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services.Services
{
    public class StoredProcService : IStoredProcService
    {
        private readonly DbConnection _dbConnection;

        public StoredProcService(DataContext context)
        {
      
            _dbConnection = context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<IngredientUsedCountSp>> GetMostUsedIngredients(int minquant, int maxquant, UnitEnum unit)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@MinQuant", minquant);
            parameters.Add("@MaxQuant", maxquant);
            parameters.Add("@MeasureType", unit);
            return await _dbConnection.QueryAsync<IngredientUsedCountSp>("GetMostUsedINgredients",parameters, commandType:System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RecipesByCategorySpDto>> GetRecipesByCategorySp()
        {
            return await _dbConnection.QueryAsync<RecipesByCategorySpDto>("exec GetRecipesByCategory");
        }

        public async Task<IEnumerable<RecipesWith6IngredientsDto>> GetRecipesWith6orMoreIngredients()
        {
            return await _dbConnection.QueryAsync<RecipesWith6IngredientsDto>("exec spGet_Recipes_With_6orMore_Ingredients");
        }
    }
}
