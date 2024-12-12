using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Http.Coins;


[ApiVersion("1.0")]
public class CoinsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetCoins(CancellationToken cancellationToken)
    {
        return Ok();
    }
}