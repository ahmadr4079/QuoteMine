using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Infrastructure.CoinMarketCap.Outputs;

public record LatestQuoteOutput(
    [property: JsonProperty("status")] JsonObject Status,
    [property: JsonProperty("data")] JsonObject Data
);