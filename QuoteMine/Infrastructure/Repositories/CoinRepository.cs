using System.Text.Json.Nodes;
using Application;
using Application.Coins.Interfaces;
using Application.Coins.Models;
using Infrastructure.CoinMarketCap.Inputs;
using Infrastructure.CoinMarketCap.Interfaces;
using Microsoft.Extensions.Options;


namespace Infrastructure.Repositories;

public class CoinRepository(ICoinMarketCapApiAdapter coinMarketCapApiAdapter, 
    IOptionsMonitor<AppSettings> optionsMonitor) : ICoinRepository
{
    public async Task<CoinQuotesModel> GetLatestCoinQuotes(string symbol, CancellationToken cancellationToken)
    {
        var latestQuote =
            await coinMarketCapApiAdapter.GetLatestQuote(new LatestQuoteInput(symbol, 
                optionsMonitor.CurrentValue.QuoteCurrencies), cancellationToken);
        if (latestQuote.Data.TryGetPropertyValue(symbol, out JsonNode? v))
        {
            var quotes = v["quote"]?.AsObject().ToDictionary(item => item.Key,
                item => item.Value["price"].GetValue<decimal>()) ?? new Dictionary<string, decimal>();
            return new CoinQuotesModel { Symbol = symbol, Quotes = quotes };
        }
        return new CoinQuotesModel { Symbol = symbol, Quotes = new Dictionary<string, decimal>() };

    }
}