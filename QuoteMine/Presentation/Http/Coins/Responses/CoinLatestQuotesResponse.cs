namespace Presentation.Http.Coins.Requests;

public class CoinLatestQuotesResponse
{
    public string Symbol { get; set; }
    public Dictionary<string, decimal> Quotes { get; set; }
}