using Application.Coins.Interfaces;
using Application.Coins.Logics;
using Infrastructure.CoinMarketCap.Adapters;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.Repositories;

namespace Presentation.Configurations.Extensions;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICoinLogic, CoinLogic>();
        services.AddScoped<ICoinRepository, CoinRepository>();
        services.AddScoped<ICoinMarketCapApiAdapter, CoinMarketCapApiAdapter>();
        services.AddMetrics();
    }
}