using Swashbuckle.AspNetCore.Filters;

namespace Application.Helpers.Exceptions;

public class ValidationExceptionDto(string type, string message) : ExceptionDto(type, message, 400)
{
    public List<ValidationExceptionItem> ValidationErrors { get; set; } = new();
}

public class ValidationExceptionItem
{
    public string Field { get; set; }
    public List<string> Messages { get; set; } = new();
}

public class ValidationExceptionExamples : IMultipleExamplesProvider<ValidationExceptionDto>
{
    public IEnumerable<SwaggerExample<ValidationExceptionDto>> GetExamples()
    {
        yield return SwaggerExample.Create("ValidationException",
            new ValidationExceptionDto("BadRequestException", ExceptionKeys.BadRequestErrorMessage)
            {
                Code = 400,
                ValidationErrors =
                [
                    new ValidationExceptionItem
                    {
                        Field = "string",
                        Messages = ["string"]
                    }
                ]
            });
    }
}