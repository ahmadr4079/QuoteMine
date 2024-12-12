using Application.Coins.Models;

namespace Application.Coins.Interfaces;

public interface ICoinLogic
{
    Task<CoinQuotesModel> GetLatestCoinQuotes(string symbol, CancellationToken cancellationToken);
}