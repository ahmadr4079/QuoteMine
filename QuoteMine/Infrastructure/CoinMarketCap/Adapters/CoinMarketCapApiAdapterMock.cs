using System.Text.Json.Nodes;
using Infrastructure.CoinMarketCap.Inputs;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.CoinMarketCap.Outputs;

namespace Infrastructure.CoinMarketCap.Adapters;

public class CoinMarketCapApiAdapterMock : ICoinMarketCapApiAdapter
{
    public async Task<LatestQuoteOutput> GetLatestQuote(LatestQuoteInput input, CancellationToken cancellationToken)
    {
        return new LatestQuoteOutput(new JsonObject(), new JsonObject());
    }
}