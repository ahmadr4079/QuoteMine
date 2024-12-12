using System.Text.Json.Nodes;
using Application;
using Application.Currencies.Interfaces;
using Application.Currencies.Models;
using Infrastructure.CoinMarketCap.Inputs;
using Infrastructure.CoinMarketCap.Interfaces;
using Microsoft.Extensions.Options;


namespace Infrastructure.Repositories;

public class CurrencyRepository(ICoinMarketCapApiAdapter coinMarketCapApiAdapter,
    IOptionsMonitor<AppSettings> optionsMonitor) : ICurrencyRepository
{
    public async Task<CurrencyQuotesModel> GetLatestCurrencyQuotes(string symbol, CancellationToken cancellationToken)
    {
        var latestQuote =
            await coinMarketCapApiAdapter.GetLatestQuote(new LatestQuoteInput(symbol,
                optionsMonitor.CurrentValue.QuoteCurrencies), cancellationToken);
        if (latestQuote.Data.TryGetPropertyValue(symbol, out JsonNode? v))
        {
            var quotes = v["quote"]?.AsObject().ToDictionary(item => item.Key,
                item => item.Value["price"].GetValue<decimal>()) ?? new Dictionary<string, decimal>();
            return new CurrencyQuotesModel { Symbol = symbol, Quotes = quotes };
        }
        return new CurrencyQuotesModel { Symbol = symbol, Quotes = new Dictionary<string, decimal>() };

    }
}