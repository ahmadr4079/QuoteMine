using Microsoft.AspNetCore.Mvc;

namespace Presentation.Http;

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
}