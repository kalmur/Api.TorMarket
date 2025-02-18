using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class ProductCategoryEntityConfiguration : EntityConfigurationBase<ProductCategoryEntity>
{
    protected override string TableName => TableNames.ProductCategory;

    protected override void ConfigureColumns(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        builder
            .Property(x => x.Id)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.ProductCategoryEntity)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        builder
            .HasIndex(pc => pc.Name);
    }
}
