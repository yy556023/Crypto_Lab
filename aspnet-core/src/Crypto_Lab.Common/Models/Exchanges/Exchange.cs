namespace Crypto_Lab.Common.Models.Exchanges;

public class Exchange
{
    /// <summary>
    /// 主鍵
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 交易所名稱
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// CoinMarketCap 標籤
    /// </summary>
    public string? Slug { get; set; }

    /// <summary>
    /// 市場上交易對數量
    /// </summary>
    public string? NumMarketPairs { get; set; }

    /// <summary>
    /// 法定貨幣種類
    /// </summary>
    public string? Fiats { get; set; }

    /// <summary>
    /// 最後更新時間(UTC)
    /// </summary>
    public DateTime LastUpdated { get; set; }
}
