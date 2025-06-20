using Api.TorMarket.Domain.Models;
using Api.TorMarket.Persistence.Constants;
using Api.TorMarket.Persistence.Entities.Configuration.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.TorMarket.Persistence.Entities.Configuration;

internal sealed class CurrencyEntityConfiguration : EntityConfigurationBase<CurrencyEntity>
{
    protected override string TableName => TableNames.Currencies;

    protected override void ConfigureColumns(EntityTypeBuilder<CurrencyEntity> builder)
    {
        builder
            .Property(currency => currency.CurrencyId)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(currency => currency.Code)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(Currency.Code_MaxLength)
            .IsUnicode(true);

        builder
            .Property(currency => currency.Symbol)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(Currency.Symbol_MaxLength)
            .IsUnicode(true);

        builder
            .Property(currency => currency.Name)
            .HasColumnOrder(ColumnOrder++)
            .IsRequired()
            .HasMaxLength(Currency.Name_MaxLength)
            .IsUnicode(true);
    }

    protected override void ConfigureIndexes(EntityTypeBuilder<CurrencyEntity> builder)
    {
        builder
            .HasKey(currency => currency.CurrencyId);
    }

    protected override void ConfigureKeys(EntityTypeBuilder<CurrencyEntity> builder)
    {
        builder
            .HasIndex(currency => currency.Code)
            .IsUnique();

        builder
            .HasIndex(currency => currency.Name)
            .IsUnique();
    }
}
