using System.Diagnostics.CodeAnalysis;
using Crypto_Lab.Common.Consts;
using Crypto_Lab.Common.Models.SymbolDetails;
using Crypto_Lab.Common.Models.Symbols;
using Microsoft.EntityFrameworkCore;

namespace Crypto_Lab.DAL.Extensions.Symbols;

public static class ExchangeModelBuilderExtensions
{
    public static void ConfigureSymbol(
        [NotNull] this ModelBuilder builder)
    {
        builder.Entity<Symbol>(b =>
        {
            b.ToTable(DbProperties.DbTablePrefix + "Symbols");

            b.HasKey(b => b.Id);

            b.Property(x => x.Id)
            .HasColumnOrder(0)
            .HasComment("主鍵")
            .HasColumnName(nameof(Symbol.Id))
            .IsRequired();

            b.Property(x => x.Name)
            .HasColumnOrder(1)
            .HasComment("交易對名稱")
            .HasColumnName(nameof(Symbol.Name))
            .HasMaxLength(DbProperties.NameMaxLength)
            .IsRequired();

            b.Property(x => x.Exchange)
            .HasColumnOrder(2)
            .HasComment("交易所名稱")
            .HasColumnName(nameof(Symbol.Exchange))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.BaseAsset)
            .HasColumnOrder(3)
            .HasComment("交易對象")
            .HasColumnName(nameof(Symbol.BaseAsset))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.Property(x => x.QuoteAsset)
            .HasColumnOrder(4)
            .HasComment("定價資產")
            .HasColumnName(nameof(Symbol.QuoteAsset))
            .HasMaxLength(DbProperties.NameMaxLength);

            b.HasIndex(x => x.BaseAsset);
            b.HasIndex(x => x.QuoteAsset);
        });

        builder.Entity<SymbolDetail>(b =>
        {
            b.ToTable(DbProperties.DbTablePrefix + "SymbolDetails");

            b.HasKey(b => b.Id);

            b.Property(x => x.Id)
            .HasColumnOrder(0)
            .HasComment("主鍵")
            .HasColumnName(nameof(SymbolDetail.Id))
            .IsRequired();

            b.Property(x => x.SymbolId)
            .HasColumnOrder(1)
            .HasComment("交易對ID")
            .HasColumnName(nameof(SymbolDetail.SymbolId))
            .IsRequired();

            b.Property(x => x.SymbolName)
            .HasColumnOrder(2)
            .HasComment("交易對名稱")
            .HasColumnName(nameof(SymbolDetail.SymbolName))
            .HasMaxLength(DbProperties.NameMaxLength)
            .IsRequired();

            b.Property(x => x.PriceChange)
            .HasColumnOrder(3)
            .HasComment("最近 24 小時的價格變動")
            .HasColumnName(nameof(SymbolDetail.PriceChange))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.PriceChangePercent)
            .HasColumnOrder(4)
            .HasComment("最近 24 小時的價格變動百分比")
            .HasColumnName(nameof(SymbolDetail.PriceChangePercent))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.WeightedAvgPrice)
            .HasColumnOrder(5)
            .HasComment("加權平均價格")
            .HasColumnName(nameof(SymbolDetail.WeightedAvgPrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.PrevClosePrice)
            .HasColumnOrder(6)
            .HasComment("前一個區間的收盤價格")
            .HasColumnName(nameof(SymbolDetail.PrevClosePrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.LastPrice)
            .HasColumnOrder(7)
            .HasComment("最後一次成交的價格")
            .HasColumnName(nameof(SymbolDetail.LastPrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.LastQty)
            .HasColumnOrder(8)
            .HasComment("最後一次成交的數量")
            .HasColumnName(nameof(SymbolDetail.LastQty))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.BidPrice)
            .HasColumnOrder(9)
            .HasComment("買方最高價格")
            .HasColumnName(nameof(SymbolDetail.BidPrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.BidQty)
            .HasColumnOrder(10)
            .HasComment("買方最高價格數量")
            .HasColumnName(nameof(SymbolDetail.BidQty))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.AskPrice)
            .HasColumnOrder(11)
            .HasComment("賣方最低價格")
            .HasColumnName(nameof(SymbolDetail.AskPrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.AskQty)
            .HasColumnOrder(12)
            .HasComment("賣方最低價格數量")
            .HasColumnName(nameof(SymbolDetail.AskQty))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.OpenPrice)
            .HasColumnOrder(13)
            .HasComment("Ticker間隔開盤價")
            .HasColumnName(nameof(SymbolDetail.OpenPrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.HighPrice)
            .HasColumnOrder(14)
            .HasComment("Ticker間隔最高價")
            .HasColumnName(nameof(SymbolDetail.HighPrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.LowPrice)
            .HasColumnOrder(15)
            .HasComment("Ticker間隔最低價")
            .HasColumnName(nameof(SymbolDetail.LowPrice))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.Volume)
            .HasColumnOrder(16)
            .HasComment("最近 24 小時的總成交量(Base)")
            .HasColumnName(nameof(SymbolDetail.Volume))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.QuoteVolume)
            .HasColumnOrder(17)
            .HasComment("最近 24 小時的總成交額(Quote)")
            .HasColumnName(nameof(SymbolDetail.QuoteVolume))
            .HasColumnType(DbProperties.TypeDecimal);

            b.Property(x => x.OpenTime)
            .HasColumnOrder(18)
            .HasComment("Ticker間隔的開始時間")
            .HasColumnName(nameof(SymbolDetail.OpenTime));

            b.Property(x => x.CloseTime)
            .HasColumnOrder(19)
            .HasComment("Ticker間隔的結束時間")
            .HasColumnName(nameof(SymbolDetail.CloseTime));

            b.Property(x => x.FirstId)
            .HasColumnOrder(20)
            .HasComment("首筆成交的 ID")
            .HasColumnName(nameof(SymbolDetail.FirstId));

            b.Property(x => x.LastId)
            .HasColumnOrder(21)
            .HasComment("末筆成交的 ID")
            .HasColumnName(nameof(SymbolDetail.LastId));

            b.Property(x => x.Count)
            .HasColumnOrder(22)
            .HasComment("時間區間內成交筆數")
            .HasColumnName(nameof(SymbolDetail.Count));
        });
    }
}
