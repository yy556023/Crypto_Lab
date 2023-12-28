namespace Crypto_Lab.BLL.Exchanges;

public interface IExchangeService
{
    Task GetCryptoList();

    Task UpdateExchangeInfo();

    Task UpdateMarketPairsInfo();

    Task UpdateMarketPairDetailsInfo();

    Task<string> GetMarketPairsByExchange(string exchangeName);
}
