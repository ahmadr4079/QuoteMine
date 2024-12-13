namespace Application.Currencies.Models;

public record CurrencyQuotesModel(string Symbol, Dictionary<string, decimal> Quotes);