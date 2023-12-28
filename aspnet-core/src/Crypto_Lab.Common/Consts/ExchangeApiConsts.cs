namespace Crypto_Lab.Common.Consts;

public static class CryptoApiConsts
{
    public const string Prefix = "CryptoApis";

    #region CoinMarketCap 貨幣市場帽
    public static class CoinMarketCap
    {
        public const string Prefix = CryptoApiConsts.Prefix + ":CoinMarketCap";

        public const string BaseApi = Prefix + ":SandBoxBaseApi";

        public const string ApiKey = Prefix + ":SandBoxApiKey";
        // 正式時候解開
        // public const string BaseApi = Prefix + ":BaseApi";
        // public const string ApiKey = Prefix + ":ApiKey";

        #region Exchange 交易所
        public static class Exchange
        {
            public const string Prefix = CoinMarketCap.Prefix + ":Exchange";

            /// <summary>
            /// 取得交易所清單
            /// </summary>
            public const string ListingsLatest = Prefix + ":ListingsLatest";

            /// <summary>
            /// 取得市場交易對清單
            /// </summary>
            public const string MarketPairsLatest = Prefix + ":MarketPairsLatest";
        }
        #endregion

        #region Cryptocurrency 加密貨幣
        public static class Cryptocurrency
        {

        }
        #endregion

        #region FIAT 法定貨幣
        public static class FIAT
        {

        }
        #endregion

    }
    #endregion
}
