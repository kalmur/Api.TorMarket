using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .ToTable(TableNames.Category)
            .HasKey(x => x.CategoryId);

        builder
            .Property(x => x.CategoryId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name);

        // Navigation
        builder
            .HasMany(x => x.Listings)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);

        // Seed categories data
        builder.HasData(CategoryData.Categories);
    }
}
