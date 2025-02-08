using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.EntityConfiguration;

public class SiteUserEntityConfiguration : IEntityTypeConfiguration<SiteUser>
{
    public void Configure(EntityTypeBuilder<SiteUser> builder)
    {
        builder
            .ToTable(TableNames.SiteUser)
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.UserName)
            .IsRequired();

        builder
            .Property(x => x.EmailAddress)
            .IsRequired();

        builder.Property(x => x.ProviderId);

        // Navigation
        builder
            .HasMany(x => x.UserProductReviews)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.UserAddresses)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
