using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Infrastructure.CoinMarketCap.Outputs;

public class LatestQuoteOutput
{
    [JsonProperty("status")]
    public JsonObject Status { get; set; }

    [JsonProperty("data")]
    public JsonObject Data { get; set; }
}