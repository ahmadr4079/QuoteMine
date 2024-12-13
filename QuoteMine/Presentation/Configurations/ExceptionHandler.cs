using Application.Helpers.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Presentation.Configurations;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var exceptionDto = new ExceptionDto();
        if (exception is UnknownException unknownException)
        {
            exceptionDto.Code = unknownException.Code;
            exceptionDto.Message = unknownException.Message;
            exceptionDto.Type = unknownException.Type;
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }

        if (exception is NotFoundException notFoundException)
        {
            exceptionDto.Code = notFoundException.Code;
            exceptionDto.Message = notFoundException.Message;
            exceptionDto.Type = notFoundException.Type;
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        }

        if (exception is BadRequestException badRequestException)
        {
            exceptionDto.Code = badRequestException.Code;
            exceptionDto.Message = badRequestException.Message;
            exceptionDto.Type = badRequestException.Type;
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }

        if (exception is Exception ex)
        {
            unknownException = new UnknownException();
            exceptionDto.Code = unknownException.Code;
            exceptionDto.Message = unknownException.Message;
            exceptionDto.Type = unknownException.Type;
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }

        await httpContext.Response.WriteAsJsonAsync(exceptionDto, cancellationToken);
        return true;
    }
}