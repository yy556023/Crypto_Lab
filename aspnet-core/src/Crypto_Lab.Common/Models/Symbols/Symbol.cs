namespace Crypto_Lab.Common.Models.Symbols;

public class Symbol
{
    /// <summary>
    /// 主鍵
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 交易對名稱
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 交易所名稱
    /// </summary>
    public string? Exchange { get; set; }

    /// <summary>
    /// 交易對象
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// 定價資產
    /// </summary>
    public string? QuoteAsset { get; set; }
}
