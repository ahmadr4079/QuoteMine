namespace Infrastructure.Currencies.Interfaces;

public interface ICurrencyRedisAdapter
{
    Task SetCacheAsync<T>(string key, T value, TimeSpan expirationTime, CancellationToken cancellationToken);
    Task<T> GetCacheAsync<T>(string key, CancellationToken cancellationToken);
}