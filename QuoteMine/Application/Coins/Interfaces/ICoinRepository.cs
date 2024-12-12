using Application.Coins.Models;

namespace Application.Coins.Interfaces;

public interface ICoinRepository
{
    Task<CoinQuotesModel> GetLatestCoinQuotes(string symbol, CancellationToken cancellationToken);
}