using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Configurations;

public class ValidationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Where(v => v.Value?.Errors.Count > 0)
                .GroupBy(x => x.Key)
                .Select(x => new ValidationExceptionItem
                {
                    Field = x.Key,
                    Messages = x.First().Value.Errors.Select(e => e?.ErrorMessage).ToList()
                })
                .ToList();

            var responseObj = new ValidationExceptionDto("ValidationException", ExceptionKeys.BadRequestErrorMessage)
            {
                Type = nameof(BadRequestException),
                Code = 400,
                Message = ExceptionKeys.BadRequestErrorMessage,
                ValidationErrors = errors
            };

            context.Result = new JsonResult(responseObj)
            {
                StatusCode = 400
            };
        }
    }
}