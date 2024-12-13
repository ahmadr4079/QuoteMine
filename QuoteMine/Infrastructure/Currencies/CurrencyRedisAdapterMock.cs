using Infrastructure.Currencies.Interfaces;

namespace Infrastructure.Currencies;

public class CurrencyRedisAdapterMock : ICurrencyRedisAdapter
{
    public async Task SetCacheAsync<T>(string key, T value, TimeSpan expirationTime,
        CancellationToken cancellationToken)
    {
    }

    public async Task<T> GetCacheAsync<T>(string key, CancellationToken cancellationToken)
    {
        return default!;
    }
}