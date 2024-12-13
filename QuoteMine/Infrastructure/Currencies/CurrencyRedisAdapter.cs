using System.Text.Json;
using Infrastructure.Currencies.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Currencies;

public class CurrencyRedisAdapter : ICurrencyRedisAdapter
{
    private readonly IConnectionMultiplexer _redisClient;

    public CurrencyRedisAdapter(IConnectionMultiplexer redisClient)
    {
        _redisClient = redisClient;
    }

    public async Task SetCacheAsync<T>(string key, T value, TimeSpan expirationTime,
        CancellationToken cancellationToken)
    {
        if (_redisClient.IsConnected)
        {
            var db = _redisClient.GetDatabase();
            var data = JsonSerializer.Serialize(value);
            await db.StringSetAsync(key, data, expirationTime);
        }
    }

    public async Task<T> GetCacheAsync<T>(string key, CancellationToken cancellationToken)
    {
        if (_redisClient.IsConnected)
        {
            var db = _redisClient.GetDatabase();
            var data = await db.StringGetAsync(key);
            return data.HasValue ? JsonSerializer.Deserialize<T>(data) : default;
        }

        return default;
    }

    public async Task<bool> IsConnectedAsync(CancellationToken cancellationToken)
    {
        return _redisClient.IsConnected;
    }
}