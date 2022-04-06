using AutoMapper;
using server.Dtos;
using server.Models;

namespace server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Ingredient, GetIngredientDto>();
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<RecipeIngredients, GetRecipeIngredientsDto>();
            CreateMap<CreateRecipeDto, Recipe>().ReverseMap();
            CreateMap<AddRecipeIngredientsDto, RecipeIngredients>().ReverseMap();
        }
    }
}
