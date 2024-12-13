using Swashbuckle.AspNetCore.Filters;

namespace Application.Helpers.Exceptions;

public class UnknownException : BaseException
{
    public UnknownException() : base(nameof(UnknownException), ExceptionKeys.Unknown, 500)
    {
    }

    public UnknownException(string type, string message) : base(type, message, 500)
    {
    }
}

public class UnknownExceptionExamples : IMultipleExamplesProvider<ExceptionDto>
{
    public IEnumerable<SwaggerExample<ExceptionDto>> GetExamples()
    {
        yield return SwaggerExample.Create(nameof(UnknownException),
            new ExceptionDto { Code = 500, Message = ExceptionKeys.Unknown, Type = nameof(UnknownException) });
    }
}