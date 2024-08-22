using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
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
    }
}
