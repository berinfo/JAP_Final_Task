using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Datas;
using server.Dtos;
using server.Models;
using server.Response;
using Server.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public IngredientService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetIngredientDto>>> GetIngredients(BaseSearch search)
        {
            var queryable = _context.Ingredients.AsQueryable();

            if (search.SortOrder == "ASC")
            {
                switch (search.SortBy)
                {
                    case "name":
                        queryable = queryable.OrderBy(x => x.Name);
                        break;
                    case "purchaseQuantity":
                        queryable = queryable.OrderBy(x => x.PurchaseQuantity);
                        break;
                    case "purchasePrice":
                        queryable = queryable.OrderBy(x => x.PurchasePrice);
                        break;
                    case "purchaseUnit":
                        queryable = queryable.OrderBy(x => x.PurchaseUnit);
                        break;
                    default:
                        queryable = queryable.OrderBy(x => x.Name);
                        break;
                }
            }
            else
            {
                switch (search.SortBy)
                {
                    case "name":
                        queryable = queryable.OrderByDescending(x => x.Name);
                        break;
                    case "purchaseQuantity":
                        queryable = queryable.OrderByDescending(x => x.PurchaseQuantity);
                        break;
                    case "purchasePrice":
                        queryable = queryable.OrderByDescending(x => x.PurchasePrice);
                        break;
                    case "purchaseUnit":
                        queryable = queryable.OrderByDescending(x => x.PurchaseUnit);
                        break;
                    default:
                        queryable = queryable.OrderByDescending(x => x.Name);
                        break;
                }
            }

            if (search.Name != null)
            {
                queryable = queryable.Where(i => i.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.MinQuant > 0 && search.MaxQuant > 0)
                queryable = queryable.Where(x => x.PurchaseQuantity > search.MinQuant && x.PurchaseQuantity <
                search.MaxQuant);

            //if (search.UnitEnum)
            //    queryable = queryable.Where(x => x.PurchaseUnit.Equals(search.UnitEnum));

            var toReturn = await queryable.Skip((int)search.Skip).Take((int)search.PageSize).ToListAsync();
            return new ServiceResponse<List<GetIngredientDto>>()
            {
                Data = _mapper.Map<List<GetIngredientDto>>(toReturn)
            };
        }
        //private static void Sort(BaseSearch search)
        //{

        //}

        public async Task<ServiceResponse<GetIngredientDto>> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);

            if (ingredient == null)
                throw new ArgumentNullException(nameof(ingredient));

            return new ServiceResponse<GetIngredientDto>()
            {
                Data = _mapper.Map<GetIngredientDto>(ingredient),
                Success = true
            };
        }
        public async Task<ServiceResponse<GetIngredientDto>> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);

            if (ingredient == null)
                throw new ArgumentNullException(nameof(ingredient));

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetIngredientDto>()
            {
                Success = true,
                Message = "Ingredient successfully deleted"
            };
        }
        public async Task<ServiceResponse<GetIngredientDto>> CreateIngredient(AddIngredientDto newIngredient)
        {
            var ingredientToAdd = _mapper.Map<Ingredient>(newIngredient);

            if (newIngredient.Name.Length == 0)
                throw new ArgumentException("Name is required");
            if (newIngredient.PurchaseQuantity <= 0 || newIngredient.PurchasePrice <= 0)
                throw new ArgumentException("Enter numbers greater than 0");

            await _context.Ingredients.AddAsync(ingredientToAdd);
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetIngredientDto>()
            {
                Data = _mapper.Map<GetIngredientDto>(ingredientToAdd),
                Success = true,
                Message = "Successfully created"
            };
        }
        public async Task<ServiceResponse<GetIngredientDto>> UpdateIngredient(int id, AddIngredientDto newIngredient)
        {
            var ingredientToUpdate = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);

            if (ingredientToUpdate == null)
                throw new ArgumentNullException(nameof(ingredientToUpdate));

            if (newIngredient.Name.Length == 0)
                throw new ArgumentException("Name is required");
            if (newIngredient.PurchaseQuantity <= 0 || newIngredient.PurchasePrice <= 0)
                throw new ArgumentException("Enter numbers greater than 0");

            ingredientToUpdate.Name = newIngredient.Name;
            ingredientToUpdate.PurchaseQuantity = newIngredient.PurchaseQuantity;
            ingredientToUpdate.PurchasePrice = newIngredient.PurchasePrice;
            ingredientToUpdate.PurchaseUnit = newIngredient.PurchaseUnit;

            await _context.SaveChangesAsync();
            return new ServiceResponse<GetIngredientDto>()
            {
                Success = true,
                Message = "Successfully updated"
            };
        }
        public async Task<ServiceResponse<List<GetIngredientDto>>> GetAllIngredients()
        {
            var dbIngredients = await _context.Ingredients
                .Select(c => _mapper.Map<GetIngredientDto>(c))
                .ToListAsync();

            return new ServiceResponse<List<GetIngredientDto>>()
            {
                Data = dbIngredients
            };
        }
    }

}
