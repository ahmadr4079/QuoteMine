using Infrastructure.CoinMarketCap.Adapters;
using Infrastructure.CoinMarketCap.Interfaces;
using Infrastructure.Currencies;
using Infrastructure.Currencies.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Test;

public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var coinMarketCapApiAdapter = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(CoinMarketCapApiAdapter));
            var currencyRedisAdapter = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(CurrencyRedisAdapter));
            services.Remove(currencyRedisAdapter);
            services.Remove(coinMarketCapApiAdapter);
            services.AddScoped<ICoinMarketCapApiAdapter, CoinMarketCapApiAdapterMock>();
            services.AddScoped<ICurrencyRedisAdapter, CurrencyRedisAdapterMock>();
        });
        builder.UseEnvironment("Development");
    }
}