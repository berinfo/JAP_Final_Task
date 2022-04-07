using AutoMapper;
using server.Dtos;
using server.Models;
using Server.Core.Dtos;

namespace server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, GetCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Ingredient, GetIngredientDto>();
            CreateMap<AddIngredientDto, Ingredient>();
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<RecipeIngredients, GetRecipeIngredientsDto>();
            CreateMap<CreateRecipeDto, Recipe>().ReverseMap();
            CreateMap<AddRecipeIngredientsDto, RecipeIngredients>().ReverseMap();
        }
    }
}
