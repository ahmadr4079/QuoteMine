namespace Application.Helpers.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string type, string message) : base(type, message, 404)
    {
    }
}