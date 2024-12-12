namespace Application;

public class AppSettings
{
    public const string Prefix = "AppSettings";
    public string CoinMarketCapApiBaseUrl { get; set; }
    public string QuoteCurrencies { get; set; }
}