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
    public class CategoryService : ICategoryService    
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context; 
        }
        public async Task<ServiceResponse<List<GetCategoryDto>>> GetCategories(int n)
        {
            var dbCategories = await _context.Categories
                .OrderByDescending(r => r.CreatedAt)
                .Select(c => _mapper.Map<GetCategoryDto>(c))
                .Take(n)
                .ToListAsync();

            return new ServiceResponse<List<GetCategoryDto>>()
            {
                Data = dbCategories
            };
        }
    }
}
