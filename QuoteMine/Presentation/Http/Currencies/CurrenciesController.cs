using Application.Currencies.Interfaces;
using Asp.Versioning;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Http.Currencies.Requests;
using Presentation.Http.Currencies.Responses;

namespace Presentation.Http.Currencies;

[ApiVersion("1.0")]
public class CurrenciesController : BaseController
{
    private readonly ICurrencyLogic _currencyLogic;
    private readonly IMapper _mapper;


    public CurrenciesController(ICurrencyLogic currencyLogic, IMapper mapper)
    {
        _currencyLogic = currencyLogic;
        _mapper = mapper;
    }


    [HttpGet("quotes/latest")]
    public async Task<ActionResult<CurrencyLatestQuotesResponse>> GetCurrencyLatestQuotes(
        [FromQuery] CurrencyLatestQuotesRequest request,
        CancellationToken cancellationToken)
    {
        var currencyQuotesModel = await _currencyLogic.GetLatestCurrencyQuotes(request.Symbol, cancellationToken);
        return _mapper.Map<CurrencyLatestQuotesResponse>(currencyQuotesModel);
    }
}