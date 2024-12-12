using Application.Coins.Interfaces;
using Asp.Versioning;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Http.Coins.Requests;

namespace Presentation.Http.Coins;


[ApiVersion("1.0")]
public class CoinsController : BaseController
{
    private readonly IMapper _mapper;
    private readonly ICoinLogic _coinLogic;


    public CoinsController(ICoinLogic coinLogic, IMapper mapper)
    {
        _coinLogic = coinLogic;
        _mapper = mapper;
    }


    [HttpGet("quotes/latest")]
    public async Task<ActionResult<CoinLatestQuotesResponse>> GetCoinLatestQuotes([FromQuery] CoinLatestQuotesRequest request,
        CancellationToken cancellationToken)
    {
        var coinQuotesModel = await _coinLogic.GetLatestCoinQuotes(request.Symbol, cancellationToken);
        return _mapper.Map<CoinLatestQuotesResponse>(coinQuotesModel);
    }
}