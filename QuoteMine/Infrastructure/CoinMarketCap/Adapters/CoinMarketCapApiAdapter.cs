using Application;
using Flurl;
using Flurl.Http;
using Infrastructure.CoinMarketCap.Inputs;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.CoinMarketCap.Outputs;
using Microsoft.Extensions.Options;

namespace Infrastructure.CoinMarketCap.Adapters;

public class CoinMarketCapApiAdapter(IOptionsMonitor<AppSettings> optionsMonitor) : ICoinMarketCapApiAdapter
{
    private readonly FlurlClient _client = new(optionsMonitor.CurrentValue.CoinMarketCapApiBaseUrl);

    public async Task<LatestQuoteOutput> GetLatestQuote(LatestQuoteInput input, CancellationToken cancellationToken)
    {
        var response = await _client.Request(optionsMonitor.CurrentValue.CoinMarketCapApiBaseUrl
                .AppendPathSegment("/v1/cryptocurrency/quotes/latest")
                .SetQueryParam("symbol", input.Symbol)
                .SetQueryParam("convert", input.Convert))
            .WithHeader("X-CMC_PRO_API_KEY", optionsMonitor.CurrentValue.CoinMarketCapApiKey)
            .AllowAnyHttpStatus()
            .GetAsync(cancellationToken: cancellationToken);
        var result = await response.GetJsonAsync<LatestQuoteOutput>();
        return result;
    }
}