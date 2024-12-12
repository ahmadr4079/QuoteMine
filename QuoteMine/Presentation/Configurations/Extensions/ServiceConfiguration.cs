using Application.Currencies.Interfaces;
using Application.Currencies.Logics;
using Infrastructure.CoinMarketCap.Adapters;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.Repositories;

namespace Presentation.Configurations.Extensions;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrencyLogic, CurrencyLogic>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ICoinMarketCapApiAdapter, CoinMarketCapApiAdapter>();
        services.AddMetrics();
    }
}