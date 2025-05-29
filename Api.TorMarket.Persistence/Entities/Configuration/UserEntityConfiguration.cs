using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class UserEntityConfiguration : EntityConfigurationBase<UserEntity>
{
    protected override string TableName => TableNames.Users;

    protected override void ConfigureColumns(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .Property(user => user.UserId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(user => user.RoleId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(user => user.ProviderId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(User.ProviderId_MaxLength);

        builder
            .Property(user => user.CreatedDate)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired();

        builder
            .Property(user => user.UpdatedDate)
            .HasColumnOrder(ColumnOrder++);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasKey(user => user.UserId);

        builder
            .HasOne(user => user.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(user => user.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasIndex(user => user.ProviderId)
            .IsUnique();
    }
}
