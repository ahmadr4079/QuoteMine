using Application.Currencies.Models;

namespace Application.Currencies.Interfaces;

public interface ICurrencyLogic
{
    Task<CurrencyQuotesModel> GetLatestCurrencyQuotes(string symbol, CancellationToken cancellationToken);
}