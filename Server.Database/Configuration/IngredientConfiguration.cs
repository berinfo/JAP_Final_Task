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
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.PurchaseQuantity).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PurchasePrice).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PurchaseUnit).IsRequired();
            builder.HasData(IngredientData.GetIngredientData());
        }
    }
}
