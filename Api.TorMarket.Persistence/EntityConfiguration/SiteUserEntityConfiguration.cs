using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.EntityConfiguration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class SiteUserEntityConfiguration : EntityConfigurationBase<SiteUserEntity>
{
    protected override string TableName => TableNames.SiteUser;

    protected override void ConfigureColumns(EntityTypeBuilder<SiteUserEntity> builder)
    {
        builder
            .Property(x => x.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.ProviderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();
    }

    protected override void ConfigureKeys(EntityTypeBuilder<SiteUserEntity> builder)
    {
        builder
            .ToTable(TableNames.SiteUser)
            .HasKey(x => x.UserId);

        builder
            .HasMany(u => u.Products)
            .WithOne(p => p.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.ProductReviews)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.Addresses)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<SiteUserEntity> builder)
    {
        builder
            .HasIndex(su => su.ProviderId)
            .IsUnique();
    }
}
