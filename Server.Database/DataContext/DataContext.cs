using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Units;
using System;

namespace server.Datas
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            var hmac = new System.Security.Cryptography.HMACSHA512();
            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("test123"));

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "user123", IsAdmin = false, PasswordHash = passwordHash, PasswordSalt = hmac.Key },
                new User { Id = 2, Username = "admin", IsAdmin = true, PasswordHash = passwordHash, PasswordSalt = hmac.Key }
                );


        }
    }
}