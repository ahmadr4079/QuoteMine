using Application;
using Application.Currencies.Interfaces;
using Application.Currencies.Models;
using Infrastructure.CoinMarketCap.Inputs;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.Currencies.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Infrastructure.Currencies;

public class CurrencyRepository(
    ICoinMarketCapApiAdapter coinMarketCapApiAdapter,
    ICurrencyRedisAdapter currencyRedisAdapter,
    IOptionsMonitor<AppSettings> optionsMonitor,
    IMemoryCache memoryCache) : ICurrencyRepository

{
    private static readonly TimeSpan ExpirationTime = TimeSpan.FromMinutes(1);


    public async Task<CurrencyQuotesModel> GetLatestCurrencyQuotes(string symbol, CancellationToken cancellationToken)
    {
        var currencyQuotesModel = await GetCurrencyQuotesCache(symbol, cancellationToken);
        if (currencyQuotesModel is null)
        {
            currencyQuotesModel = await FetchLatestCurrencyQuotes(symbol, cancellationToken);
            await SetCurrencyQuotesCache(currencyQuotesModel, cancellationToken);
        }

        return currencyQuotesModel;
    }

    private async Task SetCurrencyQuotesCache(CurrencyQuotesModel currencyQuotesModel,
        CancellationToken cancellationToken)
    {
        var currencyQuotesModelCacheKey = $"Currencies:{currencyQuotesModel.Symbol}:LatestQuotes";
        var currencyRedisAdapterIsConnected = await currencyRedisAdapter.IsConnectedAsync(cancellationToken);
        if (currencyRedisAdapterIsConnected)
            await currencyRedisAdapter.SetCacheAsync(currencyQuotesModelCacheKey, currencyQuotesModel, ExpirationTime,
                cancellationToken);
        else
            memoryCache.Set(currencyQuotesModelCacheKey, currencyQuotesModel, ExpirationTime);
    }

    private async Task<CurrencyQuotesModel> GetCurrencyQuotesCache(string symbol,
        CancellationToken cancellationToken)
    {
        var currencyQuotesModelCacheKey = $"Currencies:{symbol}:LatestQuotes";
        var currencyRedisAdapterIsConnected = await currencyRedisAdapter.IsConnectedAsync(cancellationToken);
        if (currencyRedisAdapterIsConnected)
            return await currencyRedisAdapter.GetCacheAsync<CurrencyQuotesModel>(currencyQuotesModelCacheKey,
                cancellationToken);

        return memoryCache.Get<CurrencyQuotesModel>(currencyQuotesModelCacheKey);
    }


    private async Task<CurrencyQuotesModel> FetchLatestCurrencyQuotes(string symbol,
        CancellationToken cancellationToken)
    {
        var latestQuote = await coinMarketCapApiAdapter.GetLatestQuote(
            new LatestQuoteInput(symbol, optionsMonitor.CurrentValue.QuoteCurrencies), cancellationToken);
        if (latestQuote.Data == null || !latestQuote.Data.TryGetPropertyValue(symbol, out var v))
            return new CurrencyQuotesModel(symbol, new Dictionary<string, decimal>());
        var quotes =
            v["quote"]?.AsObject().ToDictionary(item => item.Key, item => item.Value["price"].GetValue<decimal>()) ??
            new Dictionary<string, decimal>();
        return new CurrencyQuotesModel(symbol, quotes);
    }
}