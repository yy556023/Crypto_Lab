namespace Crypto_Lab.Common.Models.SymbolDetails;

public class SymbolDetail
{
    /// <summary>
    /// 主鍵
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 交易對ID
    /// </summary>
    public Guid SymbolId { get; set; }

    /// <summary>
    /// 交易對名稱
    /// </summary>
    public string? SymbolName { get; set; }

    /// <summary>
    /// 最近 24 小時的價格變動
    /// </summary>
    public decimal PriceChange { get; set; }

    /// <summary>
    /// 最近 24 小時的價格變動百分比
    /// </summary>
    public decimal PriceChangePercent { get; set; }

    /// <summary>
    /// 加權平均價格
    /// </summary>
    public decimal WeightedAvgPrice { get; set; }

    /// <summary>
    /// 前一個區間的收盤價格
    /// </summary>
    public decimal PrevClosePrice { get; set; }

    /// <summary>
    /// 最後一次成交的價格
    /// </summary>
    public decimal LastPrice { get; set; }

    /// <summary>
    /// 最後一次成交的數量
    /// </summary>
    public decimal LastQty { get; set; }

    /// <summary>
    /// 買方最高價格
    /// </summary>
    public decimal BidPrice { get; set; }

    /// <summary>
    /// 買方最高價格數量
    /// </summary>
    public decimal BidQty { get; set; }

    /// <summary>
    /// 賣方最低價格
    /// </summary>
    public decimal AskPrice { get; set; }

    /// <summary>
    /// 賣方最低價格數量
    /// </summary>
    public decimal AskQty { get; set; }

    /// <summary>
    /// Ticker間隔開盤價
    /// </summary>
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// Ticker間隔最高價
    /// </summary>
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Ticker間隔最低價
    /// </summary>
    public decimal LowPrice { get; set; }

    /// <summary>
    /// 最近 24 小時的總成交量(Base)
    /// </summary>
    public decimal Volume { get; set; }

    /// <summary>
    /// 最近 24 小時的總成交額(Quote)
    /// </summary>
    public decimal QuoteVolume { get; set; }

    /// <summary>
    /// Ticker間隔的開始時間
    /// </summary>
    public DateTime? OpenTime { get; set; }

    /// <summary>
    /// Ticker間隔的結束時間
    /// </summary>
    public DateTime? CloseTime { get; set; }

    /// <summary>
    /// 首筆成交 ID
    /// </summary>
    public long FirstId { get; set; }

    /// <summary>
    /// 末筆成交 ID
    /// </summary>
    public long LastId { get; set; }

    /// <summary>
    /// 時間區間內成交筆數
    /// </summary>
    public int Count { get; set; }
}
