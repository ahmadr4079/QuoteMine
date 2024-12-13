using System.Net;

namespace Test;

public class CurrenciesApiTest : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly TestWebApplicationFactory<Program> _factory;

    public CurrenciesApiTest(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public void TestCurrenciesLatestQuotesWithoutSymbol()
    {
        var client = _factory.CreateClient();
        var response = client.GetAsync("/api/v1/currencies/quotes/latest").Result;
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public void TestCurrenciesLatestQuotesWitSymbol()
    {
        var client = _factory.CreateClient();
        var response = client.GetAsync("/api/v1/currencies/quotes/latest?symbol=BTC").Result;
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}