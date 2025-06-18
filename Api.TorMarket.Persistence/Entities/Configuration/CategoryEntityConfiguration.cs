using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class CategoryEntityConfiguration : EntityConfigurationBase<CategoryEntity>
{
    protected override string TableName => TableNames.Categories;

    protected override void ConfigureColumns(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder
            .Property(listingCategory => listingCategory.CategoryId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(listingCategory => listingCategory.Name)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(Category.Name_MaxLength);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder
            .HasKey(listingCategory => listingCategory.CategoryId);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder
            .HasIndex(listingCategory => listingCategory.Name);
    }
}
