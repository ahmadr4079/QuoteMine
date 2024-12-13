using Application.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.Http;

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
[SwaggerResponse(500, type: typeof(ExceptionDto))]
[SwaggerResponseExample(500, typeof(UnknownExceptionExamples))]
public class BaseController : ControllerBase
{
}