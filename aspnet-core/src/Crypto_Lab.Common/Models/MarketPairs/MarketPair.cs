namespace Crypto_Lab.Common.Models.MarketPairs;

public class MarketPair
{
    /// <summary>
    /// 主鍵
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 交易對名稱
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 交易所名稱
    /// </summary>
    public string? ExchangeName { get; set; }

    /// <summary>
    /// 指定交易對象
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// 定價資產
    /// </summary>
    public string? QuoteAsset { get; set; }

    /// <summary>
    /// 價格
    /// </summary>
    public decimal Price { get; set; }
}
