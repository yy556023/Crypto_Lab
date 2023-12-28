using System.Diagnostics.CodeAnalysis;
using Crypto_Lab.Common.Consts;
using Crypto_Lab.Common.Models.MarketPairs;
using Microsoft.EntityFrameworkCore;

namespace Crypto_Lab.DAL.Extensions.MarketPairs;

public static class MarketPairModelBuilderExtensions
{
    public static void ConfigureMarketPair(
        [NotNull] this ModelBuilder builder)
    {
        builder.Entity<MarketPair>(b =>
        {
            b.ToTable(DbProperties.DbTablePrefix + "MarketPairs");

            b.HasKey(b => b.Id);

            b.Property(x => x.Id)
            .HasColumnOrder(0)
            .HasComment("主鍵")
            .HasColumnName(nameof(MarketPair.Id))
            .IsRequired();

            b.Property(x => x.Name)
            .HasColumnOrder(1)
            .HasComment("交易所名稱")
            .HasColumnName(nameof(MarketPair.Name))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.ExchangeName)
            .HasColumnOrder(2)
            .HasComment("交易所名稱")
            .HasColumnName(nameof(MarketPair.ExchangeName))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.BaseAsset)
            .HasColumnOrder(3)
            .HasComment("交易對象")
            .HasColumnName(nameof(MarketPair.BaseAsset))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.QuoteAsset)
            .HasColumnOrder(4)
            .HasComment("定價資產")
            .HasColumnName(nameof(MarketPair.QuoteAsset))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.Price)
            .HasColumnOrder(5)
            .HasComment("價格")
            .HasColumnName(nameof(MarketPair.Price))
            .HasColumnType(DbProperties.TypeDecimal);
        });
    }
}
