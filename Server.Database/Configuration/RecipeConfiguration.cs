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
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            // one to many
            builder.HasData(RecipeData.GetRecipeData());
            builder.HasOne(x => x.Category).WithMany(x => x.Recipes).HasForeignKey(x => x.CategoryId);
        }
    }
}
