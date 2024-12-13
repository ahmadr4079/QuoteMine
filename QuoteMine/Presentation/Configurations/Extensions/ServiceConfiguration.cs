using Application.Currencies.Interfaces;
using Application.Currencies.Logics;
using Infrastructure.CoinMarketCap.Adapters;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.Currencies;
using Infrastructure.Currencies.Interfaces;
using StackExchange.Redis;

namespace Presentation.Configurations.Extensions;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConfiguration = configuration.GetSection("Redis")["ConnectionString"];
        var redis = ConnectionMultiplexer.Connect(redisConfiguration);
        services.AddSingleton<IConnectionMultiplexer>(redis);
        services.AddSingleton<ICurrencyRedisAdapter, CurrencyRedisAdapter>();
        services.AddScoped<ICurrencyLogic, CurrencyLogic>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ICoinMarketCapApiAdapter, CoinMarketCapApiAdapter>();
        services.AddMetrics();
    }
}