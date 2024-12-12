using Application.Coins.Interfaces;
using Application.Coins.Models;

namespace Application.Coins.Logics;

public class CoinLogic(ICoinRepository coinRepository) : ICoinLogic
{
    public async Task<CoinQuotesModel> GetLatestCoinQuotes(string symbol, CancellationToken cancellationToken)
    {
        return await coinRepository.GetLatestCoinQuotes(symbol, cancellationToken);
    }
}