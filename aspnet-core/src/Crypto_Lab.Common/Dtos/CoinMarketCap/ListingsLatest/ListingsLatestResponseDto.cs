using Newtonsoft.Json;

namespace Crypto_Lab.Common.Dtos.CoinMarketCap.ListingsLatest;

public class ListingsLatestResponseDto
{
    public Status? Status { get; set; }
    public List<Data>? Data { get; set; }
}

public class Data
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }

    [JsonProperty("num_market_pairs")]
    public string? NumMarketPairs { get; set; }
    public List<string>? Fiats { get; set; }

    [JsonProperty("traffic_score")]
    public int TrafficScore { get; set; }
    public int Rank { get; set; }

    [JsonProperty("exchange_score")]
    public double ExchangeScore { get; set; }

    [JsonProperty("liquidity_score")]
    public double LiquidityScore { get; set; }

    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }
    public Quote? Quote { get; set; }
}

public class Quote
{
    public QuoteDetail? USD { get; set; }
}

public class QuoteDetail
{
    public decimal Volume24h { get; set; }
    public decimal Volume24hAdjusted { get; set; }
    public decimal Volume7d { get; set; }
    public decimal Volume30d { get; set; }
    public decimal PercentChangeVolume24h { get; set; }
    public decimal PercentChangeVolume7d { get; set; }
    public decimal PercentChangeVolume30d { get; set; }
    public decimal EffectiveLiquidity24h { get; set; }
    public decimal DerivativeVolumeUSD { get; set; }
    public decimal SpotVolumeUSD { get; set; }
}

public class Status
{
    public DateTime Timestamp { get; set; }
    public int ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
    public int Elapsed { get; set; }
    public int CreditCount { get; set; }
    public string? Notice { get; set; }
}
