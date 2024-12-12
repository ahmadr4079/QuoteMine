namespace Application.Coins.Models;

public class CoinQuotesModel
{
    public string Symbol { get; set; }
    public Dictionary<string, decimal> Quotes { get; set; }
}