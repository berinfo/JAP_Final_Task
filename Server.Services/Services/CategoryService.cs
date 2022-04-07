﻿using AutoMapper;
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

        public async Task<ServiceResponse<GetCategoryDto>> CreateCategory(CreateCategoryDto newCategory)
        {
            var addedCategory = _mapper.Map<Category>(newCategory);
            await _context.Categories.AddAsync(addedCategory);
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetCategoryDto>()
            {
                Data = _mapper.Map<GetCategoryDto>(addedCategory),
                Message = "Successfully created category",
                Success = true
            };
        }

        public async Task<ServiceResponse<GetCategoryDto>> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
           
            if(categoryToDelete == null)
                throw new ArgumentNullException(nameof(categoryToDelete));

            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();

            return new ServiceResponse<GetCategoryDto>()
            {
                Message = "Successfully deleted",
                Success = true
            };
        }
    }
}
