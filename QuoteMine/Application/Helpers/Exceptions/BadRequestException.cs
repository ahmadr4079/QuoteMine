namespace Application.Helpers.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string type, string message) : base(type, message, 400)
    {
    }
}