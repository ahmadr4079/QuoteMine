using Infrastructure.CoinMarketCap.Inputs;
using Infrastructure.CoinMarketCap.Outputs;

namespace Infrastructure.CoinMarketCap.Interfaces;

public interface ICoinMarketCapApiAdapter
{
    Task<LatestQuoteOutput> GetLatestQuote(LatestQuoteInput input, CancellationToken cancellationToken);
}