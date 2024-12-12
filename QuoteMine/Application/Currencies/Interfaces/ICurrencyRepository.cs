using Application.Currencies.Models;

namespace Application.Currencies.Interfaces;

public interface ICurrencyRepository
{
    Task<CurrencyQuotesModel> GetLatestCurrencyQuotes(string symbol, CancellationToken cancellationToken);
}