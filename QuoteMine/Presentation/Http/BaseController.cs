namespace Presentation.Http;

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
[SwaggerResponse(400, type: typeof(ValidationExceptionDto))]
[SwaggerResponseExample(400, typeof(ValidationExceptionExamples))]
[SwaggerResponse(500, type: typeof(ExceptionDto))]
[SwaggerResponseExample(500, typeof(UnknownExceptionExamples))]
public class BaseController : ControllerBase
{
}