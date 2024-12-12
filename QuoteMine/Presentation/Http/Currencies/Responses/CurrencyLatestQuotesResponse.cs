namespace Presentation.Http.Currencies.Responses;

public class CurrencyLatestQuotesResponse
{
    public string Symbol { get; set; }
    public Dictionary<string, decimal> Quotes { get; set; }
}