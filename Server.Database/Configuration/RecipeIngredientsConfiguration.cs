using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Models;
using Server.Database.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database.Configuration
{
    public class RecipeIngredientsConfiguration : IEntityTypeConfiguration<RecipeIngredients>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredients> builder)
        {
            builder.HasKey(x => new {x.RecipeId, x.IngredientId});
            // many to many below
            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeIngredients).HasForeignKey(x => x.RecipeId);
            builder.HasOne(x => x.Ingredient).WithMany(x => x.RecipeIngredients).HasForeignKey(x => x.IngredientId);
            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.Quantity).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.RecipeId).IsRequired();
            builder.Property(x => x.IngredientId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.HasData(RecipeIngredientsData.GetRecipeIngredientsData());
            
        }
    }
    }
