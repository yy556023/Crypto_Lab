using Crypto_Lab.BLL.Exchanges;
using Microsoft.AspNetCore.Mvc;

namespace Crypto_Lab.HttpApi.Host.Controllers.Exchanges;

[Route("api/exchange")]
[ApiController]
public class ExchangeController : ControllerBase
{
    private readonly IExchangeService _exchangeService;

    public ExchangeController(IExchangeService exchangeService)
    {
        _exchangeService = exchangeService;
    }

    [HttpGet]
    [Route("update-exchange-info")]
    public Task UpdateExchangeInfo()
    {
        return _exchangeService.UpdateExchangeInfo();
    }

    [HttpGet]
    [Route("update-market-pairs-info")]
    public Task UpdateMarketPairsInfo()
    {
        return _exchangeService.UpdateMarketPairsInfo();
    }

    [HttpGet]
    [Route("{exchangeName}")]
    public IActionResult GetMarketPairsByExchange(string exchangeName)
    {
        return Content(_exchangeService.GetMarketPairsByExchange(exchangeName).Result);
    }
}
