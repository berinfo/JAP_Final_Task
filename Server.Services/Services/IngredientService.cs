using AutoMapper;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Datas;
using server.Dtos;
using server.Models;
using server.Response;
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
        public async Task<ServiceResponse<List<GetIngredientDto>>> GetIngredients()
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
