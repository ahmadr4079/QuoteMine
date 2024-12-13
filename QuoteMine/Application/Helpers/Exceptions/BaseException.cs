using Swashbuckle.AspNetCore.Filters;

namespace Application.Helpers.Exceptions;

public class BaseException : Exception
{
    public BaseException(string type, string message, int code) : base(type)
    {
        Type = type;
        Message = message;
        Code = code;
    }

    public BaseException(string type, string message, int code, object detailObject) : base(type)
    {
        Type = type;
        Message = message;
        Code = code;
        DetailObject = detailObject;
    }

    public string Type { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    public object? DetailObject { get; set; }

    public SwaggerExample<ExceptionDto> SwaggerExample =>
        Swashbuckle.AspNetCore.Filters.SwaggerExample.Create(Type,
            new ExceptionDto { Code = Code, Message = Message, Type = Type });
}