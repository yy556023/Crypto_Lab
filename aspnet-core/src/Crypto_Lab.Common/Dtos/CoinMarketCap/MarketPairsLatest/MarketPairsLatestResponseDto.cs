
using Newtonsoft.Json;

namespace Crypto_Lab.Common.Dtos.CoinMarketCap.MarketPairsLatest;

public class MarketPairsLatestResponseDto
{
    public Status? Status { get; set; }
    public Data? Data { get; set; }
}

public class Data
{
    public MarketPairs? Binance { get; set; }
}

public class DataDetail
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }

    [JsonProperty("num_market_pairs")]
    public int NumMarketPairs { get; set; }
    public decimal Volume24h { get; set; }
    public List<MarketPairs>? MarketPairs { get; set; }
}

public class MarketPairs
{
    [JsonProperty("market_id")]
    public int MarketId { get; set; }

    [JsonProperty("market_pair")]
    public string? MarketPair { get; set; }
    public string? Category { get; set; }

    [JsonProperty("fee_type")]
    public string? FeeType { get; set; }

    [JsonProperty("market_url")]
    public string? MarketUrl { get; set; }

    [JsonProperty("market_pair_base")]
    public Asset? MarketPairBase { get; set; }

    [JsonProperty("market_pair_quote")]
    public Asset? MarketPairQuote { get; set; }
    public Quote? Quote { get; set; }
}

public class Quote
{
    [JsonProperty("exchange_reported")]
    public QuoteDetail? ExchangeReported { get; set; }
    public QuoteDetail? USD { get; set; }
}

public class QuoteDetail
{
    public decimal Price { get; set; }
    public decimal Volume24hBase { get; set; }
    public decimal Volume24hQuote { get; set; }
    public decimal VolumePercentage { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class Asset
{
    [JsonProperty("currency_id")]
    public int CurrencyId { get; set; }

    [JsonProperty("currency_symbol")]
    public string? CurrencySymbol { get; set; }

    [JsonProperty("exchange_symbol")]
    public string? ExchangeSymbol { get; set; }

    [JsonProperty("currency_type")]
    public string? CurrencyType { get; set; }
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