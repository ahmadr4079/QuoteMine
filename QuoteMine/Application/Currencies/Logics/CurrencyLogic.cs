using Application.Currencies.Interfaces;
using Application.Currencies.Models;

namespace Application.Currencies.Logics;

public class CurrencyLogic(ICurrencyRepository currencyRepository) : ICurrencyLogic
{
    public async Task<CurrencyQuotesModel> GetLatestCurrencyQuotes(string symbol, CancellationToken cancellationToken)
    {
        return await currencyRepository.GetLatestCurrencyQuotes(symbol, cancellationToken);
    }
}