namespace Application.Currencies.Models;

public class CurrencyQuotesModel
{
    public string Symbol { get; set; }
    public Dictionary<string, decimal> Quotes { get; set; }
}