using Application;
using Application.Currencies.Interfaces;
using Application.Currencies.Models;
using Infrastructure.CoinMarketCap.Inputs;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.Currencies.Interfaces;
using Microsoft.Extensions.Options;

namespace Infrastructure.Currencies;

public class CurrencyRepository(
    ICoinMarketCapApiAdapter coinMarketCapApiAdapter,
    ICurrencyRedisAdapter currencyRedisAdapter,
    IOptionsMonitor<AppSettings> optionsMonitor) : ICurrencyRepository

{
    private static readonly TimeSpan ExpirationTime = TimeSpan.FromMinutes(1);


    public async Task<CurrencyQuotesModel> GetLatestCurrencyQuotes(string symbol, CancellationToken cancellationToken)
    {
        var currencyQuotesModelCacheKey = $"Currencies:{symbol}:LatestQuotes";
        var currencyQuotesModel =
            await currencyRedisAdapter.GetCacheAsync<CurrencyQuotesModel>(currencyQuotesModelCacheKey,
                cancellationToken);
        if (currencyQuotesModel is null)
        {
            var latestQuote =
                await coinMarketCapApiAdapter.GetLatestQuote(new LatestQuoteInput(symbol,
                    optionsMonitor.CurrentValue.QuoteCurrencies), cancellationToken);
            if (latestQuote.Data.TryGetPropertyValue(symbol, out var v))
            {
                var quotes = v["quote"]?.AsObject().ToDictionary(item => item.Key,
                    item => item.Value["price"].GetValue<decimal>()) ?? new Dictionary<string, decimal>();
                currencyQuotesModel = new CurrencyQuotesModel { Symbol = symbol, Quotes = quotes };
            }
            else
            {
                currencyQuotesModel = new CurrencyQuotesModel
                    { Symbol = symbol, Quotes = new Dictionary<string, decimal>() };
            }

            await currencyRedisAdapter.SetCacheAsync(currencyQuotesModelCacheKey, currencyQuotesModel, ExpirationTime,
                cancellationToken);
        }

        return currencyQuotesModel;
    }
}