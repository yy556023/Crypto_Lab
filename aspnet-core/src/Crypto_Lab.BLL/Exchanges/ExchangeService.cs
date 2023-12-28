using Crypto_Lab.Common.Commons;
using Crypto_Lab.Common.Consts;
using Crypto_Lab.Common.Dtos.CoinMarketCap.ListingsLatest;
using Crypto_Lab.Common.Dtos.CoinMarketCap.MarketPairsLatest;
using Crypto_Lab.Common.Models.Exchanges;
using Crypto_Lab.Common.Models.MarketPairs;
using Crypto_Lab.DAL.EntityFrameworkCore;
using Crypto_Lab.DAL.EntityFrameworkCore.Symbols;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Crypto_Lab.BLL.Exchanges;

public class ExchangeService : IExchangeService
{
    private readonly SymbolRepository _symbolRepository;
    private readonly ExchangeRepository _exchangeRepository;
    private readonly CryptoDbContext _context;
    //private readonly Logger<ExchangeService> _logger;
    private readonly IConfiguration _configuration;

    public ExchangeService(
        SymbolRepository symbolRepository,
        ExchangeRepository exchangeRepository,
        CryptoDbContext context,
        IConfiguration configuration)
    {
        _symbolRepository = symbolRepository;
        _exchangeRepository = exchangeRepository;
        _context = context;
        _configuration = configuration;
    }

    public Task GetCryptoList()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 更新交易所清單資訊
    /// </summary>
    /// <returns></returns>
    public async Task UpdateExchangeInfo()
    {
        var baseUrl = _configuration.GetSection(CryptoApiConsts.CoinMarketCap.BaseApi).Value!;
        var endPoint = _configuration.GetSection(CryptoApiConsts.CoinMarketCap.Exchange.ListingsLatest).Value!;

        var apiUrl = baseUrl + endPoint;
        var apiKey = _configuration.GetSection(CryptoApiConsts.CoinMarketCap.ApiKey).Value!;

        //_logger.LogInformation("API Url:【{apiUrl}】", apiUrl);

        var header = new Dictionary<string, string>();
        header.Add("X-CMC_PRO_API_KEY", apiKey);

        try
        {
            var content = await RestSharpHelper.GetAsync(apiUrl, header);

            var response = JsonConvert.DeserializeObject<ListingsLatestResponseDto>(content);

            if (response != null && response.Data != null)
            {
                var items = response.Data
                    .Select(x => new Exchange
                    {
                        Name = x.Name,
                        Slug = x.Slug,
                        Fiats = x.Fiats != null ? string.Join(",", x.Fiats).Trim(',') : string.Empty,
                        NumMarketPairs = x.NumMarketPairs,
                        LastUpdated = x.LastUpdated,
                    }).ToList();

                foreach (var item in items)
                {
                    await _exchangeRepository.InsertAsync(item);
                }
            }
        }
        catch (Exception ex)
        {
            // Log
            throw;
        }
    }

    /// <summary>
    /// 更新交易對清單資訊
    /// </summary>
    /// <returns></returns>
    public async Task UpdateMarketPairsInfo()
    {
        var baseUrl = _configuration.GetSection(CryptoApiConsts.CoinMarketCap.BaseApi).Value!;
        var endPoint = _configuration.GetSection(CryptoApiConsts.CoinMarketCap.Exchange.MarketPairsLatest).Value!;

        var apiUrl = baseUrl + endPoint;
        var apiKey = _configuration.GetSection(CryptoApiConsts.CoinMarketCap.ApiKey).Value!;

        //_logger.LogInformation("API Url:【{apiUrl}】", apiUrl);

        var headers = new Dictionary<string, string>();
        headers.Add("X-CMC_PRO_API_KEY", apiKey);

        var parameters = new Dictionary<string, string>();
        parameters.Add("slug", "binance");
        parameters.Add("convert", "USD");

        try
        {
            var content = await RestSharpHelper.GetAsync(apiUrl, headers, parameters);

            var response = JsonConvert.DeserializeObject<MarketPairsLatestResponseDto>(content);

            if (response != null && response.Data != null)
            {
                //var items = response.Data.Binance!.MarketPairs
                //    .Select(x => new MarketPair
                //    {
                //        Name = x.MarketPair,
                //        ExchangeName = response.Data.Binance.Name,
                //        Price = x.Quote.USD.Price,
                //        BaseAsset = x.MarketPairBase.CurrencySymbol,
                //        QuoteAsset = x.MarketPairQuote.CurrencySymbol
                //    }).ToList();

                //foreach (var item in items)
                //{
                //    _context.MarketPairs.Add(item);
                //    _context.SaveChanges();
                //}
                var item = new MarketPair
                {
                    Name = response.Data.Binance.MarketPair,
                    ExchangeName = "Binance",
                    Price = response.Data.Binance.Quote.USD.Price,
                    BaseAsset = response.Data.Binance.MarketPairBase.CurrencySymbol,
                    QuoteAsset = response.Data.Binance.MarketPairQuote.CurrencySymbol
                };

                _context.MarketPairs.Add(item);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            // Log
            throw;
        }
    }

    public Task UpdateMarketPairDetailsInfo()
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetMarketPairsByExchange(string exchangeName)
    {
        var items = await _context.MarketPairs
                        .Where(x => x.ExchangeName == exchangeName)
                        .ToListAsync();

        return JsonConvert.SerializeObject(items, Formatting.Indented);
    }
}
