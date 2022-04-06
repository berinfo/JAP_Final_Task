using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.SeedData
{
    public class CategoryData
    {
        public static List<Category> GetCategoriesData()
        {
            var categories = new List<Category>()
            {
            new Category { Id = 1, Name = "Category1", CreatedAt = new DateTime(2021, 3, 3, 5, 25, 4) },
                new Category { Id = 2, Name = "Category2", CreatedAt = new DateTime(2021, 4, 4, 6, 15, 14) },
                new Category { Id = 3, Name = "Category3", CreatedAt = new DateTime(2020, 4, 6, 3, 17, 25) },
                new Category { Id = 4, Name = "Category4", CreatedAt = new DateTime(2019, 5, 6, 2, 2, 2) },
                new Category { Id = 5, Name = "Category5", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 6, Name = "Category6", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 7, Name = "Category7", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 8, Name = "Category8", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 9, Name = "Category9", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 10, Name = "Category10", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 11, Name = "Category11", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 12, Name = "Category12", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 13, Name = "Category13", CreatedAt = new DateTime(2018, 5, 7, 1, 15, 15) },
                new Category { Id = 14, Name = "Category14", CreatedAt = new DateTime(2017, 5, 7, 1, 15, 15) },
                new Category { Id = 15, Name = "Category15", CreatedAt = new DateTime(2017, 6, 8, 1, 16, 15) },
                new Category { Id = 16, Name = "Category16", CreatedAt = new DateTime(2017, 6, 9, 1, 17, 15) },
                new Category { Id = 17, Name = "Category17", CreatedAt = new DateTime(2017, 6, 8, 1, 18, 15) },
                new Category { Id = 18, Name = "Category18", CreatedAt = new DateTime(2017, 6, 9, 1, 19, 15) },
                new Category { Id = 19, Name = "Category19", CreatedAt = new DateTime(2017, 6, 8, 1, 20, 15) },
                new Category { Id = 20, Name = "Category20", CreatedAt = new DateTime(2017, 6, 9, 1, 21, 15) }
                };
            return categories;
        }
    }
}
