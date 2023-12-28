using System.Diagnostics.CodeAnalysis;
using Crypto_Lab.Common.Consts;
using Crypto_Lab.Common.Models.Exchanges;
using Microsoft.EntityFrameworkCore;

namespace Crypto_Lab.DAL.Extensions.Exchanges;

public static class ExchangeModelBuilderExtensions
{
    public static void ConfigureExchange(
        [NotNull] this ModelBuilder builder)
    {
        builder.Entity<Exchange>(b =>
        {
            b.ToTable(DbProperties.DbTablePrefix + "Exchanges");

            b.HasKey(b => b.Id);

            b.Property(x => x.Id)
            .HasColumnOrder(0)
            .HasComment("主鍵")
            .HasColumnName(nameof(Exchange.Id))
            .IsRequired();

            b.Property(x => x.Name)
            .HasColumnOrder(1)
            .HasComment("交易所名稱")
            .HasColumnName(nameof(Exchange.Name))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.Slug)
            .HasColumnOrder(2)
            .HasComment("交易所名稱")
            .HasColumnName(nameof(Exchange.Slug))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.NumMarketPairs)
            .HasColumnOrder(3)
            .HasComment("市場上交易對數量")
            .HasColumnName(nameof(Exchange.NumMarketPairs));


            b.Property(x => x.Fiats)
            .HasColumnOrder(4)
            .HasComment("交易所可兌換法定貨幣(JSON)")
            .HasColumnName(nameof(Exchange.Fiats));


            b.Property(x => x.LastUpdated)
            .HasColumnOrder(5)
            .HasComment("最後更新時間")
            .HasColumnName(nameof(Exchange.LastUpdated));
        });
    }
}
