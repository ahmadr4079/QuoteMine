namespace Application.Helpers.Exceptions;

public class ExceptionDto
{
    protected ExceptionDto(string type, string message, int code)
    {
        Type = type;
        Message = message;
        Code = code;
    }

    protected ExceptionDto(string type, string message, int code, object detail)
    {
        Type = type;
        Message = message;
        Code = code;
        Detail = detail;
    }

    public ExceptionDto()
    {
    }

    public string? Type { get; set; }
    public string? Message { get; set; }
    public int? Code { get; set; }
    public object? Detail { get; set; }
}